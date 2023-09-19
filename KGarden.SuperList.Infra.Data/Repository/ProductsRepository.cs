using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using KGarden.SuperList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KGarden.SuperList.Infra.Data.Repository
{
	public class ProductsRepository : RepositoryDBR<Products>, IProductsRepository
	{
        public ProductsRepository(DBRContext context)
            :base(context) 
        {

        }

        public override async Task<Products> GetById(Guid id)
        {
            return await _context.Products.Include(x => x.Categories).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Products> GetByProductName(string name)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
        }

		public async Task<Products> GetByCategoryId(Guid categoryId)
		{
			return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryId == categoryId);
		}
	}
}
