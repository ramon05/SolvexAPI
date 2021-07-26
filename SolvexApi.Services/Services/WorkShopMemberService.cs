using AutoMapper;
using FluentValidation;
using GenericApi.Bl.DTOs;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;

namespace GenericApi.Services.Services
{
    public interface IWorkShopMemberService : IBaseService<WorkShopMember, WorkShopMemberDto>{ 
    }
    public class WorkShopMemberService : BaseService<WorkShopMember, WorkShopMemberDto>, IWorkShopMemberService
    {
        public WorkShopMemberService(
            IWorkShopMemberRepository repository, 
            IMapper mapper, 
            IValidator<WorkShopMemberDto> validator) : base(repository, mapper, validator)
        {
        }
    }
}
