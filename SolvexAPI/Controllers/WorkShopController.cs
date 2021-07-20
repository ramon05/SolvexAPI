﻿using AutoMapper;
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
    public class WorkShopController : ControllerBase
    {
        private readonly IWorkShopRepository _workShopRepository;
        private readonly IMapper _mapper;

        public WorkShopController(IWorkShopRepository workShopRepository, IMapper mapper)
        {
            _workShopRepository = workShopRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var workShop = _workShopRepository.Query();
            var workShopDtos = _mapper.Map<IEnumerable<WorkShopDto>>(workShop);
            return Ok(workShopDtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var workShopResult =  _workShopRepository.Get(id);
            var workShopDto = _mapper.Map<WorkShopDto>(workShopResult);
            return Ok(workShopDto);
        }
    
        [HttpPost]
         public async Task<IActionResult> Post(WorkShopDto workShopDto)
         {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var workShopResult = _mapper.Map<WorkShop>(workShopDto);
            await _workShopRepository.Add(workShopResult);
            return Ok(workShopResult);
         }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] WorkShopDto workShopDto, int id)
        {
            var workShopResult = _mapper.Map<WorkShop>(workShopDto);
            workShopResult.Id = id;

            await _workShopRepository.Update(workShopResult);
            return Ok(workShopResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var workShopResult = _workShopRepository.Delete(id);

            return Ok(workShopResult);
        }
    }
}
