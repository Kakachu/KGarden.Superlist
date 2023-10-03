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
	public class ListItemsRepository : RepositoryDBR<ListItems>, IListItemsRepository
	{
        public ListItemsRepository(DBRContext context)
            :base(context)
        {
            
        }

		public async Task<List<ListItems>> GetAllItensByListId(Guid id)
		{
			return await _context.ListItems.AsNoTracking().Where(x => x.ListId == id).ToListAsync();
		}
	}
}
