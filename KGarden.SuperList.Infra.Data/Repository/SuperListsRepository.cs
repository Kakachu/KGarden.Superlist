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

		public async Task<List<SuperLists>> GetAllByUserId(Guid userId)
		{
			return await _context.SuperLists.Where(x => x.UserId == userId).ToListAsync();
		}

		public async Task<List<SuperLists>> GetAllByIdentification(string identification)
		{
			return await _context.SuperLists.Where(x => x.Identification == identification).ToListAsync();
		}

		public async Task<bool> AnyByName(string name)
		{
			var context = await _context.SuperLists.AnyAsync(x => x.Name == name);
			return context;
		}
	}
}
