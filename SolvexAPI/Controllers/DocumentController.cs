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
	public class DocumentController : ControllerBase
	{
		private readonly IDocumentRepository _documentRepository;
		private readonly IMapper _mapper;

		public DocumentController(IDocumentRepository documentService, IMapper mapper)
		{
			_documentRepository = documentService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult Get()
		{
            var documents = _documentRepository.Query();
            var documentDtos = _mapper.Map<IEnumerable<DocumentDto>>(documents);
            return Ok(documentDtos);

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var documentResult = await _documentRepository.Get(id);
			var documentDto = _mapper.Map<DocumentDto>(documentResult);
			return Ok(documentDto);
		}

		[HttpPost]
		public async Task<IActionResult> Post(DocumentDto documentDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var documentResult = _mapper.Map<Document>(documentDto);
			await _documentRepository.Add(documentResult);
			return Ok(documentResult);
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] DocumentDto documentDto, int id)
		{
			var documentResult = _mapper.Map<Document>(documentDto);
			documentResult.Id = id;

			await _documentRepository.Update(documentResult);
			return Ok(documentResult);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var documentResult = await _documentRepository.Delete(id);

			return Ok(documentResult);
		}
	}
}
