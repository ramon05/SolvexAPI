﻿using BC = BCrypt.Net.BCrypt;
using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService service) : base(service)
        {
            _userService = service;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestDto model)
        {
            var response = await _userService.GetToken(model);

            if (response is null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        public override async Task<IActionResult> Post([FromBody] UserDto dto)
        {

            dto.Password = BC.HashPassword(dto.Password);
            var result = await _service.AddAsync(dto);

            if (result.IsSuccess is false)
                return UnprocessableEntity(result);

            return CreatedAtAction(WebRequestMethods.Http.Get, new { id = result.Entity.Id }, result.Entity);
        }
    }
}
