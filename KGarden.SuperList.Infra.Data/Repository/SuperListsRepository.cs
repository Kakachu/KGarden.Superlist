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
	public class SuperListsRepository : RepositoryDBR<SuperLists>, ISuperListsRepository
	{
		public SuperListsRepository(DBRContext context)
			: base(context)

		{

		}

		public async Task<List<SuperLists>> GetAllById(Guid id)
		{
			return await _context.SuperLists.Where(x => x.Id == id).ToListAsync();
		}

		public async Task<List<SuperLists>> GetAllIncludeById(Guid id)
		{
			var context = await _context.SuperLists.Include(x => x.Lists)
			.Where(x => x.Id == id).ToListAsync();

			return context;
		}

		public async Task<List<SuperLists>> GetAllIncludeByIdentification(string identification)
		{
			var context = await _context.SuperLists.Include(x => x.Lists)
				.Where(x => x.Identification == identification).ToListAsync();

			return context;
		}
	}
}
