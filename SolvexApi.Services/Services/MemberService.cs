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
    public interface IMemberService : IBaseService<Member, MemberDto>{ 
    }
    public class MemberService : BaseService<Member, MemberDto>, IMemberService
    {
        public MemberService(
            IMemberRepository repository, 
            IMapper mapper, 
            IValidator<MemberDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}
