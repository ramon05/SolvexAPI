using SolvexApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Model.Interfaces
{
    public interface IWorkShopService
    {
        IEnumerable<WorkShop> GetAll();
        WorkShop GetById(int id);
        Task<WorkShop> Create(WorkShop workShop);
        Task<WorkShop> Update(WorkShop workShop);
        WorkShop Delete(int id);
    }
}
