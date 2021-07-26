using GenericApi.Model.Interfaces;
using GenericApi.Model.DataContext;
using GenericApi.Model.Entities;
using GenericApi.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repositories
{
    public interface IWorkShopMemberRepository : IBaseRepository<WorkShopMember> { }
    public class WorkShopMemberRepository : BaseRepository<WorkShopMember>, IWorkShopMemberRepository
    {
        public WorkShopMemberRepository(WorkShopDbContext context) : base(context)
        {
        }
    }
}
