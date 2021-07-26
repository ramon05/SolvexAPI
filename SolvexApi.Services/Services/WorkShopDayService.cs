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
    public interface IWorkShopDayService : IBaseService<WorkShopDay, WorkShopDayDto>{ 
    }
    public class WorkShopDayService : BaseService<WorkShopDay, WorkShopDayDto>, IWorkShopDayService
    {
        public WorkShopDayService(
            IWorkShopDayRepository repository, 
            IMapper mapper, 
            IValidator<WorkShopDayDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}
