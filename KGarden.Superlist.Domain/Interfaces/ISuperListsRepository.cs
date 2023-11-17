using KGarden.Superlist.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.Interfaces
{
	public interface ISuperListsRepository : IRepositoryDBR<SuperLists>
	{
		Task<List<SuperLists>> GetAllByUserId(Guid userId);

		Task<List<SuperLists>> GetAllByIdentification(string identification);

		Task<bool> AnyByName(string name);
	}
}
