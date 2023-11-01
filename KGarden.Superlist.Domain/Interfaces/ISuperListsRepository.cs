using KGarden.Superlist.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.Interfaces
{
	public interface ISuperListsRepository : IRepositoryDBR<SuperLists>
	{
		Task<List<SuperLists>> GetAllById(Guid id);

		Task<List<SuperLists>> GetAllIncludeById(Guid id);

		Task<List<SuperLists>> GetAllIncludeByIdentification(string identification);

		Task<bool> AnyByName(string name);
	}
}
