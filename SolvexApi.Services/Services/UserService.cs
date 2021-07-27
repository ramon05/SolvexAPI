using BC = BCrypt.Net.BCrypt;
using AutoMapper;
using FluentValidation;
using GenericApi.Bl.DTOs;
using GenericApi.Core.Settings;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Services.Services
{
    public interface IUserService : IBaseService<User, UserDto>{
        Task<AuthenticateResponseDto> GetToken(AuthenticateRequestDto model);
    }
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private readonly JwtSettings _jwtSettings;
        public UserService(
            IUserRepository repository, 
            IMapper mapper, 
            IValidator<UserDto> validator,
            IOptions<JwtSettings> jwtSettings) : base(repository, mapper, validator)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticateResponseDto> GetToken(AuthenticateRequestDto model)
        {
            var user = await _repository.Query()
                .Where(x => x.UserName == model.Username)
                .Select(x => new {
                    x.Id,
                    x.UserName,
                    x.Name,
                    x.LastName,
                    x.Password
                })
                .FirstOrDefaultAsync();

            var isValidPassword = BC.Verify(model.Password, user.Password);

            if (user is null || !isValidPassword)
                return null;

            var response = new AuthenticateResponseDto
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.Name,
                LastName = user.LastName
            };

            response.Token = GenerateJwtToken(response);

            return response;
        }

        private string GenerateJwtToken(AuthenticateResponseDto user)
        {
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var symmetricSecurityKey = new SymmetricSecurityKey(key);

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claimsIdentity = new ClaimsIdentity(new[] {
                new Claim("id", user.Id.ToString()),
                new Claim("username",user.Username)
            });

            var claims = new Dictionary<string, object>
            {
                { "name", user.FirstName },
                { "lastName", user.LastName },
            };

            var description = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Claims = claims,
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                SigningCredentials = signingCredentials
            };

            var handler = new JwtSecurityTokenHandler();

            var securityToken = handler.CreateToken(description);

            var token = handler.WriteToken(securityToken);

            return token;
        }
    }
}
