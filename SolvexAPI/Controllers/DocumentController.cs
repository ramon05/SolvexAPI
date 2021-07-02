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
	public class DocumentController : ControllerBase
	{
		private readonly IDocumentService _documentService;
		private readonly IMapper _mapper;

		public DocumentController(IDocumentService documentService, IMapper mapper)
		{
			_documentService = documentService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult Get()
		{
			//var document = from d in _documentService.GetAll()
			//			select new DocumentDto()
			//			{
			//				Id = d.Id,
			//				Deleted = d.Deleted,
			//				FileName = d.FileName,
			//				OriginalName = d.OriginalName,
			//				ContentType = d.ContentType,
			//				DeletedDate = d.DeletedDate,
			//				CreatedDate = d.CreatedDate,
			//				UpdatedDate = d.UpdatedDate,
			//				CreatedBy = d.CreatedBy,
			//				DeletedBy = d.DeletedBy,
			//				UpdatedBy = d.UpdatedBy
			//			};

			//return document;
			var documents = _documentService.GetAll();
			var documentDtos = _mapper.Map<IEnumerable<DocumentDto>>(documents);
			return Ok(documentDtos);

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var documentResult = await _documentService.GetById(id);
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
			await _documentService.Create(documentResult);
			return Ok(documentResult);
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] DocumentDto documentDto, int id)
		{
			var documentResult = _mapper.Map<Document>(documentDto);
			documentResult.Id = id;

			await _documentService.Update(documentResult);
			return Ok(documentResult);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var documentResult = await _documentService.Delete(id);

			return Ok(documentResult);
		}
	}
}
