using KGarden.Superlist.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.Interfaces
{
	public interface IListItemsRepository : IRepositoryDBR<ListItems>
	{
		Task<List<ListItems>> GetAllItensByListId(Guid listId);
	}
}
