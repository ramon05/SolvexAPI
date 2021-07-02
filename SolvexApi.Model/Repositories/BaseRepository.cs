using Microsoft.EntityFrameworkCore;
using SolvexApi.Core.BaseModel.Base;
using SolvexApi.Model.DataContext;
using SolvexApi.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvexApi.Model.Repositories
{
	public class BaseRepository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly WorkShopDbContext _workShopDbContext;
		private DbSet<T> _entities;

		public BaseRepository(WorkShopDbContext workShopDbContext)
		{
			_workShopDbContext = workShopDbContext;
			_entities = workShopDbContext.Set<T>();
		}

		public async Task<T> Create(T entity)
		{
			_entities.Add(entity);
		    await _workShopDbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<T> Delete(int id)
		{
			T entity = await GetById(id);
			_entities.Remove(entity);
			_workShopDbContext.SaveChanges();
			return entity;
		}

		public  IEnumerable<T> GetAll()
		{
			return _entities.AsEnumerable();
		}

		public async Task<T> GetById(int id)
		{
			return await _entities.FindAsync(id);
		}

		public async Task<T> Update(T entity)
		{
			_entities.Update(entity);
			await _workShopDbContext.SaveChangesAsync();
			return entity;
		}
	}
}
