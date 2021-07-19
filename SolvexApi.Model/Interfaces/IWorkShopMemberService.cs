using SolvexApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Model.Interfaces
{
    public interface IWorkShopMemberService
    {
        IEnumerable<WorkShopMember> GetAll();
        WorkShopMember GetById(int id);
        Task<WorkShopMember> Create(WorkShopMember workShopMember);
        Task<WorkShopMember> Update(WorkShopMember workShopMember);
        WorkShopMember Delete(int id);
    }
}
