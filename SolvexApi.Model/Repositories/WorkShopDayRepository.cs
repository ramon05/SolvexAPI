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
    public interface IWorkShopDayRepository : IBaseRepository<WorkShopDay> { }
    public class WorkShopDayRepository : BaseRepository<WorkShopDay>, IWorkShopDayRepository
    {
        public WorkShopDayRepository(WorkShopDbContext context) : base(context)
        {
        }
    }
}
