using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Interfaces;
using SolvexApi.Model.Repositories;
using SolvexApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolvexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkShopController : BaseController<WorkShop, WorkShopDto>
    {
        public WorkShopController(IBaseService<WorkShop, WorkShopDto> service) : base(service)
        {
        }
    }
}
