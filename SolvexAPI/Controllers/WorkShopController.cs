using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopController : BaseController<WorkShop, WorkShopDto>
    {
        public WorkShopController(IWorkShopService service) : base(service)
        {
        }
    }
}
