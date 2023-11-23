using KGarden.Superlist.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Interfaces
{
	public interface IProductsAppService : IDisposable
	{
		Task<ProductsViewModel> GetById(Guid id);

		Task<ProductsViewModel> GetByProductName(string name);

		Task<ProductsViewModel> GetByCategoryId(Guid categoryId);

		Task Register(ProductsViewModel viewModel);

		Task Update(ProductsViewModel viewModel);

		Task Remove(Guid id);
	}
}
