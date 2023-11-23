using AutoMapper;
using KGarden.Superlist.Application.Interfaces;
using KGarden.Superlist.Application.ViewModels;
using KGarden.Superlist.Domain.Commands.Lists;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Services
{
	public class ListsAppService : IListsAppService
	{
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _bus;
		private readonly IListsRepository _listsRepository;

		public ListsAppService(IMapper mapper,
							   IMediatorHandler bus,
							   IListsRepository listsRepository)
		{
			_mapper = mapper;
			_bus = bus;
			_listsRepository = listsRepository;
		}

		public async Task<ListsViewModel> GetById(Guid id)
		{
			var listsViewModel = _mapper.Map<ListsViewModel>(await _listsRepository.GetById(id));
			return listsViewModel;
		}

		public async Task<List<ListsViewModel>> GetAllBySuperListId(Guid superListId)
		{
			var listsViewModel = _mapper.Map<List<ListsViewModel>>(await _listsRepository.GetAllBySuperListId(superListId));
			return listsViewModel;
		}

		public async Task<List<ListsViewModel>> GetAllByIdentification(string identification)
		{
			var listsViewModel = _mapper.Map<List<ListsViewModel>>(await _listsRepository.GetAllByIdentification(identification));
			return listsViewModel;
		}

		public async Task<List<ListsViewModel>> GetAllByCategory(Guid categoryId)
		{
			var listsViewModel = _mapper.Map<List<ListsViewModel>>(await _listsRepository.GetAllByCategory(categoryId));
			return listsViewModel;
		}

		public async Task Register(ListsViewModel viewModel)
		{
			var registerCommand = _mapper.Map<RegisterListsCommand>(viewModel);
			await _bus.SendCommand(registerCommand);
		}

		public Task Update(ListsViewModel viewModel)
		{
			throw new NotImplementedException();
		}

		public async Task Remove(Guid id)
		{
			var removeCommand = _mapper.Map<RemoveListsCommand>(new ListsViewModel { Id = id });
			await _bus.SendCommand(removeCommand);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
