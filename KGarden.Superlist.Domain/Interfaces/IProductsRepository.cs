using KGarden.Superlist.Domain.Models;
using System;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.Interfaces
{
	public interface IProductsRepository : IRepositoryDBR<Products>
	{
		Task<Products> GetByProductName(string name);

		Task<Products> GetByCategoryId(Guid category);
	}
}
