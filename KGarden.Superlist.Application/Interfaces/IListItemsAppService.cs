using KGarden.Superlist.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Interfaces
{
	public interface IListItemsAppService : IDisposable
	{
		Task<ListItemsViewModel> GetById(Guid id);

		Task<List<ListItemsViewModel>> GetAllItensByListId(Guid listId);

		Task Register(ListItemsViewModel viewModel);

		Task Update(ListItemsViewModel viewModel);

		Task Remove(Guid id);
	}
}
