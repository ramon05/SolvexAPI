using SolvexApi.Core.BaseModel.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Model.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		IEnumerable<T> GetAll();
		Task<T> GetById(int id);
		Task<T> Create(T entity);
		Task<T> Update(T entity);
		Task<T> Delete(int id);
	}
}
