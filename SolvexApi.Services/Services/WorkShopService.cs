using AutoMapper;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Services.Services
{
    public interface IWorkShopService : IBaseService<WorkShop, WorkShopDto>{ 
    }
    public class WorkShopService : BaseService<WorkShop, WorkShopDto>, IWorkShopService
    {
        public WorkShopService(IWorkShopRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
