using KGarden.Superlist.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.Interfaces
{
	public interface ICategoriesAppService : IDisposable
	{
		Task<CategoriesViewModel> GetById(Guid id);

		Task<CategoriesViewModel> GetByName(string name);

		Task<CategoriesViewModel> GetByDescription(string description);
	}
}
