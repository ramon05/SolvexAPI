using Microsoft.AspNetCore.Mvc;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Services.Services;
using System.Threading.Tasks;

namespace SolvexAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class DocumentController : BaseController<Document, DocumentDto>
	{
		public DocumentController(IBaseService<Document, DocumentDto> service) : base(service)
		{
		}
	}
}
