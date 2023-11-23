using AutoMapper;
using KGarden.Superlist.Application.Interfaces;
using KGarden.Superlist.Application.ViewModels;
using KGarden.Superlist.Domain.Commands.Categories;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Services
{
	public class CategoriesAppService : ICategoriesAppService
	{
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _bus;
		private readonly ICategoriesRepository _categoriesRepository;

		public CategoriesAppService(IMapper mapper,
									IMediatorHandler bus,
									ICategoriesRepository categoriesRepository)
        {
            _mapper = mapper;
			_bus = bus;
			_categoriesRepository = categoriesRepository;
        }

		public async Task<CategoriesViewModel> GetById(Guid id)
		{
			var categoriesViewModel = _mapper.Map<CategoriesViewModel>(await _categoriesRepository.GetById(id));
			return categoriesViewModel;
		}

		public async Task<CategoriesViewModel> GetByDescription(string description)
		{
			var categoriesViewModel = _mapper.Map<CategoriesViewModel>(await _categoriesRepository.GetByDescription(description));
			return categoriesViewModel;
		}

		public async Task<CategoriesViewModel> GetByName(string name)
		{
			var categoriesViewModel = _mapper.Map<CategoriesViewModel>(await _categoriesRepository.GetByName(name));
			return categoriesViewModel;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public async Task Register(CategoriesViewModel viewModel)
		{
			var registerCommand = _mapper.Map<RegisterCategoriesCommand>(viewModel);
			await _bus.SendCommand(registerCommand);
		}

		public async Task Update(CategoriesViewModel viewModel)
		{
			var updateCommand = _mapper.Map<UpdateCategoriesCommand>(viewModel);
			await _bus.SendCommand(updateCommand);
		}
	}
}
