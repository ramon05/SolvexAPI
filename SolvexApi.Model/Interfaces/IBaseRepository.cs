using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> Query();
        Task<TEntity> Get(int id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
    }
}
