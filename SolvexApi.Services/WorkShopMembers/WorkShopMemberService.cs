using SolvexApi.Model.Entities;
using SolvexApi.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Services.WorkShopMembers
{
    public class WorkShopMemberService : IWorkShopMemberService
    {
        private readonly IRepository<WorkShopMember> _workShopMemberRepository;

        public WorkShopMemberService(IRepository<WorkShopMember> workShopMemberRepository)
        {
            _workShopMemberRepository = workShopMemberRepository;
        }

        public IEnumerable<WorkShopMember> GetAll() => _workShopMemberRepository.GetAll().Where(x => x.Deleted == false);

        public WorkShopMember GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public async Task<WorkShopMember> Create(WorkShopMember workShopMember)
        {
            workShopMember.CreatedDate = DateTime.Now;
            workShopMember.Deleted = false;
            await _workShopMemberRepository.Create(workShopMember);
            return workShopMember;
        }

        public async Task<WorkShopMember> Update(WorkShopMember workShopMember)
        {
            workShopMember.UpdatedDate = DateTime.Now;
            await _workShopMemberRepository.Update(workShopMember);
            return workShopMember;
        }

        public WorkShopMember Delete(int id)
        {
            var workShopMemberToDelete = GetById(id);
            workShopMemberToDelete.Deleted = true;
            workShopMemberToDelete.DeletedDate = DateTime.Now;
            return workShopMemberToDelete;
        }
    }
}
