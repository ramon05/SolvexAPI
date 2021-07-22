using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolvexApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolvexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity, TDto> : ControllerBase
    {
        protected readonly IBaseService<TEntity, TDto> _service;

        public BaseController(IBaseService<TEntity, TDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _service.GetAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto dto)
        {
            var result = await _service.AddAsync(dto);

            if (result.IsSuccess is false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Post([FromRoute] int id, [FromBody] TDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (result is null)
                return NotFound($"The record with id {id} was not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _service.DeleteByIdAsync(id);

            if (result is null)
                return NotFound($"The record with id {id} was not found");

            return Ok(result);
        }

    }
}
