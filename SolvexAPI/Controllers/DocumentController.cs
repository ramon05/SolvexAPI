using Microsoft.AspNetCore.Mvc;
using SolvexApi.Bl.DTOs;
using SolvexApi.Services.Services;
using System.Threading.Tasks;

namespace SolvexAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class DocumentController : ControllerBase
	{
		private readonly IDocumentService _service;

		public DocumentController(IDocumentService service)
		{
			_service = service;
		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
            var documents = await _service.GetAllAsync();
            return Ok(documents);

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var documentResult = await _service.GetAsync(id);
			return Ok(documentResult);
		}

		[HttpPost]
		public async Task<IActionResult> Post(DocumentDto documentDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var documentResult = await _service.AddAsync(documentDto);
			return Ok(documentResult);
		}

		[HttpPut]
		public async Task<IActionResult> Put([FromBody] DocumentDto documentDto, int id)
		{

			var documentResult = await _service.UpdateAsync(id, documentDto);
			return Ok(documentResult);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			var documentResult = await _service.DeleteByIdAsync(id);

			return Ok(documentResult);
		}
	}
}
