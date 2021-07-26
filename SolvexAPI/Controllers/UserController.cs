using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
