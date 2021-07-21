﻿using AutoMapper;
using SolvexApi.Bl.DTOs;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Services.Services
{
    public interface IWorkShopMemberService : IBaseService<WorkShopMember, WorkShopMemberDto>{ 
    }
    public class WorkShopMemberService : BaseService<WorkShopMember, WorkShopMemberDto>
    {
        public WorkShopMemberService(IWorkShopMemberRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
