using KGarden.Superlist.Domain.Models;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.Interfaces
{
	public interface ICategoriesRepository : IRepositoryDBR<Categories>
	{
		Task<Categories> GetByName(string name);

		Task<Categories> GetByDescription(string description);
	}
}
