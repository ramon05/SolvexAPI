using GenericApi.Model.Interfaces;
using GenericApi.Model.DataContext;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Repositories
{
    public interface IMemberRepository : IBaseRepository<Member> { }
    class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(WorkShopDbContext context) : base(context)
        {

        }
    }
}
