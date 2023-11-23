using AutoMapper;
using KGarden.Superlist.Application.Interfaces;
using KGarden.Superlist.Application.ViewModels;
using KGarden.Superlist.Domain.Commands.ListItems;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Services
{
	public class ListItemsAppService : IListItemsAppService
	{
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _bus;
		private readonly IListItemsRepository _listItemsRepository;

		public ListItemsAppService(IMapper mapper,
								   IMediatorHandler bus,
								   IListItemsRepository listItemsRepository)
		{
			_mapper = mapper;
			_bus = bus;
			_listItemsRepository = listItemsRepository;
		}

		public async Task<ListItemsViewModel> GetById(Guid id)
		{
			var listItemViewModel = _mapper.Map<ListItemsViewModel>(await _listItemsRepository.GetById(id));
			return listItemViewModel;
		}

		public async Task<List<ListItemsViewModel>> GetAllItensByListId(Guid listId)
		{
			var listItemsViewModel = _mapper.Map<List<ListItemsViewModel>>(await _listItemsRepository.GetAllItensByListId(listId));
			return listItemsViewModel;
		}

		public async Task Register(ListItemsViewModel viewModel)
		{
			var registerCommand = _mapper.Map<RegisterListItemsCommand>(viewModel);
			await _bus.SendCommand(registerCommand);
		}

		public async Task Remove(Guid id)
		{
			var removeCommand = _mapper.Map<RemoveListItemsCommand>(new ListItemsViewModel() { Id = id });
			await _bus.SendCommand(removeCommand);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
