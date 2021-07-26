using AutoMapper;
using FluentValidation;
using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;

namespace GenericApi.Services.Services
{
    public interface IUserService : IBaseService<User, UserDto>{ 
    }
    public class UserService : BaseService<User, UserDto>, IUserService
    {
        public UserService(
            IUserRepository repository, 
            IMapper mapper, 
            IValidator<UserDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}
