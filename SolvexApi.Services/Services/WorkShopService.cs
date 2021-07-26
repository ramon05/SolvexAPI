using AutoMapper;
using FluentValidation;
using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using GenericApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Services.Services
{
    public interface IWorkShopService : IBaseService<WorkShop, WorkShopDto>{ 
    }
    public class WorkShopService : BaseService<WorkShop, WorkShopDto>, IWorkShopService
    {
        public WorkShopService(
            IWorkShopRepository repository, 
            IMapper mapper, 
            IValidator<WorkShopDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}
