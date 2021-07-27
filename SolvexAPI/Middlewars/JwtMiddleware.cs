using GenericApi.Core.Settings;
using GenericApi.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Middlewars
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<JwtMiddleware> _logger;
        public JwtMiddleware(RequestDelegate next, IOptions<JwtSettings> jwtSetting, ILogger<JwtMiddleware> logger)
        {
            _next = next;
            _jwtSettings = jwtSetting.Value;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var authHeader = context.Request.Headers["Authorization"];

            var token = authHeader.FirstOrDefault()?.Split(" ").Last();

            if (token is null)
                await _next(context);

            await attachUserToContext(context, userService, token);
                        
        }

        private async Task attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                var user = await userService.GetByIdAsync(userId);
                context.Items["User"] = user;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }
        }
    }
}
