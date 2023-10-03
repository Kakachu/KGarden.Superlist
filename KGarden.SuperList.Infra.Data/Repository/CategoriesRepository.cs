using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using KGarden.SuperList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KGarden.SuperList.Infra.Data.Repository
{
	public class CategoriesRepository : RepositoryDBR<Categories>, ICategoriesRepository
	{
		public CategoriesRepository(DBRContext context)
			: base(context)
		{

		}

		public async Task<Categories> GetByDescription(string description)
		{
			return await _context.Categories.FirstOrDefaultAsync(c => c.Description == description);
		}

		public async Task<Categories> GetByName(string name)
		{
			return await _context.Categories.SingleOrDefaultAsync(c => c.Name == name);
		}
	}
}
