using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using GenericApi.Services.Services;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopDayController : BaseController<WorkShopDay, WorkShopDayDto>
    {
        public WorkShopDayController(IWorkShopDayService service) : base(service)
        {
        }
    }
}
