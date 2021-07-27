using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
    public class DocumentController : BaseController<Document, DocumentDto>
    {
        public DocumentController(IDocumentService service) : base(service)
        {
        }
    }
}
