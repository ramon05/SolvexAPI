using AutoMapper;
using FluentValidation;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Repositories;
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
