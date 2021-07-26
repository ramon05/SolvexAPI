using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using GenericApi.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopMemberController : BaseController<WorkShopMember, WorkShopMemberDto>
    {
        public WorkShopMemberController(IWorkShopMemberService service) : base(service) 
        {
        }
    }
}
