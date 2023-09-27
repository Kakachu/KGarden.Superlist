using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using KGarden.SuperList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KGarden.SuperList.Infra.Data.Repository
{
	public class ListsRepository : RepositoryDBR<Lists>, IListsRepository
	{
		public ListsRepository(DBRContext context)
			: base(context)
		{

		}

		public async Task<List<Lists>> GetAllByIdentification(string identification)
		{
			return await _context.Lists.AsNoTracking().Where(x => x.Identification == identification).ToListAsync();
		}

		public async Task<List<Lists>> GetAllByCategory(Guid categoryId)
		{
			return await _context.Lists.AsNoTracking().Where(x => x.CategoryId == categoryId).ToListAsync();
		}
	}
}
