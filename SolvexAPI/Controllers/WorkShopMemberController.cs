using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Interfaces;
using SolvexApi.Model.Repositories;
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
        private readonly IWorkShopMemberRepository _workShopMemberRepository;
        private readonly IMapper _mapper;

        public WorkShopMemberController(IWorkShopMemberRepository workShopMemberRepository, IMapper mapper)
        {
            _workShopMemberRepository = workShopMemberRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var workShopMember = _workShopMemberRepository.Query();
            var workShopMemberDtos = _mapper.Map<IEnumerable<WorkShopMemberDto>>(workShopMember);
            return Ok(workShopMemberDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workShopMemberResult = _workShopMemberRepository.Get(id);
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
            await _workShopMemberRepository.Add(workShopMemberResult);
            return Ok(workShopMemberResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] WorkShopMemberDto workShopMemberDto, int id)
        {
            var workShopMemberResult = _mapper.Map<WorkShopMember>(workShopMemberDto);
            workShopMemberResult.Id = id;

            await _workShopMemberRepository.Update(workShopMemberResult);
            return Ok(workShopMemberResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var workShopMemberResult = _workShopMemberRepository.Delete(id);

            return Ok(workShopMemberResult);
        }
    }
}
