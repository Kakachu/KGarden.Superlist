using KGarden.Superlist.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Interfaces
{
	public interface ISuperListsAppService : IDisposable
	{
		Task<SuperListsViewModel> GetById(Guid id);

		Task<List<SuperListsViewModel>> GetAllById(Guid id);

		Task<List<SuperListsViewModel>> GetAllIncludeById(Guid id);

		Task<List<SuperListsViewModel>> GetAllIncludeByIdentification(string identification);

		Task Register(SuperListsViewModel viewModel);

		Task Update(SuperListsViewModel viewModel);

		Task Remove(Guid id);
	}
}
