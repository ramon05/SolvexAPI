using SolvexApi.Model.DataContext;
using SolvexApi.Model.Entities;
using SolvexApi.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolvexApi.Model.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member> { }
    class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(WorkShopDbContext context) : base(context)
        {

        }
    }
}
