using SolvexApi.Model.DataContext;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Interfaces;
using SolvexApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Model.Repositories
{
    public interface IWorkShopMemberRepository : IBaseRepository<WorkShopMember> { }
    public class WorkShopMemberRepository : BaseRepository<WorkShopMember>, IWorkShopMemberRepository
    {
        public WorkShopMemberRepository(WorkShopDbContext context) : base(context)
        {
        }
    }
}
