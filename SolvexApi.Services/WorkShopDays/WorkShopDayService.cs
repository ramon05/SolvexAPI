using SolvexApi.Model.Entities;
using SolvexApi.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Services.WorkShopDays
{
    public class WorkShopDayService : IWorkShopDayService
    {
        private readonly IRepository<WorkShopDay> _workShopDayRepository;

        public WorkShopDayService(IRepository<WorkShopDay> workShopDayRepository)
        {
            _workShopDayRepository = workShopDayRepository;
        }

        public async Task<WorkShopDay> Create(WorkShopDay workShopDay)
        {
            workShopDay.CreatedDate = DateTime.Now;
            workShopDay.Deleted = false;
            await _workShopDayRepository.Create(workShopDay);
            return workShopDay;
        }

        public IEnumerable<WorkShopDay> GetAll() => _workShopDayRepository.GetAll().Where(x => x.Deleted == false);


        public WorkShopDay GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public async Task<WorkShopDay> Update(WorkShopDay workShopDay)
        {
            workShopDay.UpdatedDate = DateTime.Now;
            await _workShopDayRepository.Update(workShopDay);
            return workShopDay;
        }

        public WorkShopDay Delete(int id)
        {
            var workShopDayToDelete = GetById(id);
            workShopDayToDelete.Deleted = true;
            workShopDayToDelete.DeletedDate = DateTime.Now;
            return workShopDayToDelete;
        }
    }
}
