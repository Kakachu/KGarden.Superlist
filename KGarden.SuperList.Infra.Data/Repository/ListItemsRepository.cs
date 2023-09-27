using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using KGarden.SuperList.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

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
