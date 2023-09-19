using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.Interfaces
{
	public interface IRepositoryDBR<TEntity> : IDisposable where TEntity : class
	{
		Task<TEntity> Add(TEntity obj);

		Task<List<TEntity>> AddRange(List<TEntity> listObj);

		Task<TEntity> GetById(Guid Id);

		Task<ICollection<TEntity>> GetAll();

		Task<TEntity> Update(TEntity obj, Guid key);

		TEntity Remove(TEntity obj);

		void RemoveRange(IEnumerable<TEntity> listObj);
	}
}
