using SolvexApi.Model.Entities;
using SolvexApi.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Services.WorkShops
{
    public class WorkShopService : IWorkShopService
    {
        private readonly IRepository<WorkShop> _workShopRepository;

        public WorkShopService(IRepository<WorkShop> workShopRepository)
        {
            _workShopRepository = workShopRepository;
        }

        public IEnumerable<WorkShop> GetAll() => _workShopRepository.GetAll().Where(x => x.Deleted == false);

        public WorkShop GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public async Task<WorkShop> Create(WorkShop workShop)
        {
            workShop.CreatedDate = DateTime.Now;
            workShop.Deleted = false;
            await _workShopRepository.Create(workShop);
            return workShop;
        }

        public async Task<WorkShop> Update(WorkShop workShop)
        {
            workShop.UpdatedDate = DateTime.Now;
            await _workShopRepository.Update(workShop);
            return workShop;
        }

        public WorkShop Delete(int id)
        {
            var workShopToDelete = GetById(id);
            workShopToDelete.Deleted = true;
            workShopToDelete.DeletedDate = DateTime.Now;
            return workShopToDelete;
        }
    }
}
