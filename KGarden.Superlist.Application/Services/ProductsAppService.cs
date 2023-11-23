using AutoMapper;
using KGarden.Superlist.Application.Interfaces;
using KGarden.Superlist.Application.ViewModels;
using KGarden.Superlist.Domain.Commands.Products;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Services
{
	public class ProductsAppService : IProductsAppService
	{
		private readonly IMapper _mapper;
		private readonly IMediatorHandler _bus;
		private readonly IProductsRepository _productsRepository;

		public ProductsAppService(IMapper mapper,
								  IMediatorHandler bus,
								  IProductsRepository productsRepository)
		{
			_mapper = mapper;
			_bus = bus;
			_productsRepository = productsRepository;
		}

		public async Task<ProductsViewModel> GetById(Guid id)
		{
			var productsViewModel = _mapper.Map<ProductsViewModel>(await _productsRepository.GetById(id));
			return productsViewModel;
		}

		public async Task<ProductsViewModel> GetByCategoryId(Guid categoryId)
		{
			var productsViewModel = _mapper.Map<ProductsViewModel>(await _productsRepository.GetByCategoryId(categoryId));
			return productsViewModel;
		}

		public async Task<ProductsViewModel> GetByProductName(string name)
		{
			var productsViewModel = _mapper.Map<ProductsViewModel>(await _productsRepository.GetByProductName(name));
			return productsViewModel;
		}

		public async Task Register(ProductsViewModel viewModel)
		{
			var registerCommand = _mapper.Map<RegisterProductsCommand>(viewModel);
			await _bus.SendCommand(registerCommand);
		}

		public async Task Update(ProductsViewModel viewModel)
		{
			var updateCommand = _mapper.Map<UpdateProductsCommand>(viewModel);
			await _bus.SendCommand(updateCommand);
		}

		public async Task Remove(Guid id)
		{
			var removeCommand = _mapper.Map<RemoveProductsCommand>(new ProductsViewModel() { Id = id });
			await _bus.SendCommand(removeCommand);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
