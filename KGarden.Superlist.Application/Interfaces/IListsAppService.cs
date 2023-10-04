using KGarden.Superlist.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Interfaces
{
	public interface IListsAppService : IDisposable
	{
		Task<ListsViewModel> GetById(Guid id);

		Task<List<ListsViewModel>> GetAllBySuperListId(Guid superListId);

		Task<List<ListsViewModel>> GetAllByIdentification(string identification);

		Task<List<ListsViewModel>> GetAllByCategory(Guid categoryId);

		Task Register(ListsViewModel viewModel);

		Task Update(ListsViewModel viewModel);

		Task Remove(Guid id);
	}
}
