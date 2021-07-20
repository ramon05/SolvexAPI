using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolvexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var workShop = _memberRepository.Query();
            var workShopDtos = _mapper.Map<IEnumerable<MemberDto>>(workShop);
            return Ok(workShopDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workShopResult = _memberRepository.Get(id);
            var workShopDto = _mapper.Map<MemberDto>(workShopResult);
            return Ok(workShopDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var workShopResult = _mapper.Map<Member>(memberDto);
            await _memberRepository.Add(workShopResult);
            return Ok(workShopResult);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] MemberDto memberDto, int id)
        {
            var workShopResult = _mapper.Map<Member>(memberDto);
            workShopResult.Id = id;

            await _memberRepository.Update(workShopResult);
            return Ok(workShopResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var workShopResult = _memberRepository.Delete(id);

            return Ok(workShopResult);
        }
    }
}
