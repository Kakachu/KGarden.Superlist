using KGarden.Superlist.Domain.Core.Commands;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.Interfaces
{
	public interface IUnitOfWorkDBR
	{
		Task BeginTransaction();

		Task<CommandResponse> Commit();

		Task<CommandResponse> CommitTransaction();

		Task Rollback();
	}
}
