using KGarden.Superlist.Domain.Interfaces;
using KGarden.SuperList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.SuperList.Infra.Data.Repository
{
	public class RepositoryDBR<TEntity> : IRepositoryDBR<TEntity> where TEntity : class
	{
		protected readonly DBRContext _context;

		public RepositoryDBR(DBRContext context)
        {
            _context = context;
        }

		public virtual async Task<TEntity> Add(TEntity obj)
		{
			await _context.Set<TEntity>().AddAsync(obj);
			return obj;
		}

		public virtual async Task<List<TEntity>> AddRange(List<TEntity> listObj)
		{
			await _context.Set<TEntity>().AddRangeAsync(listObj);
			return listObj;
		}

		public virtual async Task<TEntity> GetById(Guid id)
		{
			return await _context.Set<TEntity>().FindAsync(id);
		}

		public virtual async Task<ICollection<TEntity>> GetAll()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		public virtual async Task<TEntity> Update(TEntity obj, Guid key)
		{
			if (obj == null)
				return null;

			TEntity exist = await _context.Set<TEntity>().FindAsync(key);
			if(exist != null)
			{
				_context.Entry(exist).CurrentValues.SetValues(obj);
			}
			return exist;
		}

		public TEntity Remove(TEntity obj)
		{
			return _context.Set<TEntity>().Remove(obj).Entity;
		}

		public void RemoveRange(IEnumerable<TEntity> listObj)
		{
			_context.Set<TEntity>().RemoveRange(listObj);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
