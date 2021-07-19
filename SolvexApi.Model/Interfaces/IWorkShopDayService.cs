using SolvexApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Model.Interfaces
{
    public interface IWorkShopDayService
    {
        IEnumerable<WorkShopDay> GetAll();
        WorkShopDay GetById(int id);
        Task<WorkShopDay> Create(WorkShopDay workShopDay);
        Task<WorkShopDay> Update(WorkShopDay workShopDay);
        WorkShopDay Delete(int id);
    }
}
