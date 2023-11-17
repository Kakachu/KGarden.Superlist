using KGarden.Superlist.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Interfaces
{
	public interface ISuperListsAppService : IDisposable
	{
		Task<SuperListsViewModel> GetById(Guid id);

		Task<List<SuperListsViewModel>> GetAllByUserId(Guid userId);

		Task<List<SuperListsViewModel>> GetAllByIdentification(string identification);

		Task Register(SuperListsViewModel viewModel);

		Task Update(SuperListsViewModel viewModel);

		Task Remove(Guid id);
	}
}
