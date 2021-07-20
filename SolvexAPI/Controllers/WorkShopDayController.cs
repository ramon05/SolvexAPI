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
    public class WorkShopDayController : ControllerBase
    {
        private readonly IWorkShopDayRepository _workShopDayRepository;
        private readonly IMapper _mapper;
        public WorkShopDayController(IWorkShopDayRepository workShopDayRepository, IMapper mapper)
        {
            _workShopDayRepository = workShopDayRepository;
            _mapper = mapper;
        }

		[HttpGet]
		public IActionResult Get()
		{
			var workShopDay = _workShopDayRepository.Query();
			var documentDtos = _mapper.Map<IEnumerable<WorkShopDayDto>>(workShopDay);
			return Ok(documentDtos);

		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var workShopDayResult = _workShopDayRepository.Get(id);
			var workShopDayDto = _mapper.Map<WorkShopDayDto>(workShopDayResult);
			return Ok(workShopDayDto);
		}

		[HttpPost]
		public async Task<IActionResult> Post(WorkShopDayDto workShopDayDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var workShopDayResult = _mapper.Map<WorkShopDay>(workShopDayDto);
			await _workShopDayRepository.Add(workShopDayResult);
			return Ok(workShopDayResult);
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] WorkShopDayDto workShopDayDto, int id)
		{
			var workShopDayResult = _mapper.Map<WorkShopDay>(workShopDayDto);
			workShopDayResult.Id = id;

			await _workShopDayRepository.Update(workShopDayResult);
			return Ok(workShopDayResult);
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var workShopDayResult =  _workShopDayRepository.Delete(id);

			return Ok(workShopDayResult);
		}
	}
}
