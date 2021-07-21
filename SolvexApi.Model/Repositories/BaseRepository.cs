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
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBase
	{
		private readonly IDbContext _context;
		private DbSet<TEntity> _set;

		public BaseRepository(IDbContext context)
		{
			_context = context;
			_set = context.Set<TEntity>();
		}

		public IQueryable<TEntity> Query()
		{
			return _set.AsQueryable();
		}

		public async Task<TEntity> Add(TEntity entity)
		{
			var result = await _set.AddAsync(entity);
			await _context.SaveChangesAsync();

			return result.Entity;
		}

		public async Task<TEntity> Delete(int id)
		{
			TEntity entity = await Get(id);
			_set.Remove(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<TEntity> Get(int id)
		{
			var entity = await _set.Where(x => x.Id == id).FirstOrDefaultAsync();
			return entity;
		}

		public async Task<TEntity> Update(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}
	}
}
