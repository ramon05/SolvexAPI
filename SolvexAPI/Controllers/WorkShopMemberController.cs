using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolvexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopMemberController : ControllerBase
    {
        private readonly IWorkShopMemberService _workShopMemberService;
        private readonly IMapper _mapper;

        public WorkShopMemberController(IWorkShopMemberService workShopMemberService, IMapper mapper)
        {
            _workShopMemberService = workShopMemberService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var workShopMember = _workShopMemberService.GetAll();
            var workShopMemberDtos = _mapper.Map<IEnumerable<WorkShopMemberDto>>(workShopMember);
            return Ok(workShopMemberDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workShopMemberResult = _workShopMemberService.GetById(id);
            var workShopMemberDto = _mapper.Map<WorkShopMemberDto>(workShopMemberResult);
            return Ok(workShopMemberDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(WorkShopMemberDto workShopMemberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var workShopMemberResult = _mapper.Map<WorkShopMember>(workShopMemberDto);
            await _workShopMemberService.Create(workShopMemberResult);
            return Ok(workShopMemberResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] WorkShopMemberDto workShopMemberDto, int id)
        {
            var workShopMemberResult = _mapper.Map<WorkShopMember>(workShopMemberDto);
            workShopMemberResult.Id = id;

            await _workShopMemberService.Update(workShopMemberResult);
            return Ok(workShopMemberResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var workShopMemberResult = _workShopMemberService.Delete(id);

            return Ok(workShopMemberResult);
        }
    }
}
