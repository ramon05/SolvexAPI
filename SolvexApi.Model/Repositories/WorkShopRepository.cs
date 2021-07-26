using GenericApi.Model.Interfaces;
using GenericApi.Model.DataContext;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repositories
{
    public interface IWorkShopRepository : IBaseRepository<WorkShop> { }
    public class WorkShopRepository : BaseRepository<WorkShop>, IWorkShopRepository
    {
        public WorkShopRepository(WorkShopDbContext context): base(context)
        {
        }
    }
}
