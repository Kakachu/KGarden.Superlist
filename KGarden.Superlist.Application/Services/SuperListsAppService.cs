using KGarden.Superlist.Application.Interfaces;
using KGarden.Superlist.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Services
{
	public class SuperListsAppService : ISuperListsAppService
	{
		public Task<List<SuperListsViewModel>> GetAllById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<List<SuperListsViewModel>> GetAllIncludeById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<List<SuperListsViewModel>> GetAllIncludeByIdentification(string identification)
		{
			throw new NotImplementedException();
		}

		public Task<SuperListsViewModel> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task Register(SuperListsViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public Task Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task Update(SuperListsViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
