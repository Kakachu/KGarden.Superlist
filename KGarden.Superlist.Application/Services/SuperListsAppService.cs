using AutoMapper;
using KGarden.Superlist.Application.Interfaces;
using KGarden.Superlist.Application.ViewModels;
using KGarden.Superlist.Domain.Commands.SuperLists;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Services
{
	public class SuperListsAppService : ISuperListsAppService
	{
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _bus;
		private readonly ISuperListsRepository _superListsRepository;

		public SuperListsAppService(IMapper mapper,
									IMediatorHandler bus,
									ISuperListsRepository superListsRepository)
        {
            _mapper = mapper;
			_bus = bus;
			_superListsRepository = superListsRepository;
        }

        public async Task<List<SuperListsViewModel>> GetAllByUserId(Guid userId)
		{
			var superListsViewModel = _mapper.Map<List<SuperListsViewModel>>(await _superListsRepository.GetAllByUserId(userId));
			return superListsViewModel;
		}

		public async Task<List<SuperListsViewModel>> GetAllByIdentification(string identification)
		{
			var superListsViewModel = _mapper.Map<List<SuperListsViewModel>>(await _superListsRepository.GetAllByIdentification(identification));
			return superListsViewModel;
		}

		public async Task<SuperListsViewModel> GetById(Guid id)
		{
			var superListsViewModel = _mapper.Map<SuperListsViewModel>(await _superListsRepository.GetById(id));
			return superListsViewModel;
		}

		public async Task Register(SuperListsViewModel viewModel)
		{
			var registerCommand = _mapper.Map<RegisterSuperListsCommand>(viewModel);
			await _bus.SendCommand(registerCommand);
		}

		public async Task Update(SuperListsViewModel viewModel)
		{
			var updateCommand = _mapper.Map<UpdateSuperListsCommand>(viewModel);
			await _bus.SendCommand(updateCommand);
		}

		public async Task Remove(Guid id)
		{
			var removeCommand = _mapper.Map<RemoveSuperListsCommand>(new SuperListsViewModel { Id = id });
			await _bus.SendCommand(removeCommand);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
