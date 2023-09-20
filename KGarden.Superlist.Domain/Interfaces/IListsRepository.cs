using KGarden.Superlist.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.Interfaces
{
	public interface IListsRepository : IRepositoryDBR<Lists>
	{
		Task<List<Lists>> GetAllByIdentification(string identification);

		Task<List<ListItems>> GetAllItensByListId(Guid id);

		Task<List<Lists>> GetAllByCategory(Guid categoryId);
	}
}
