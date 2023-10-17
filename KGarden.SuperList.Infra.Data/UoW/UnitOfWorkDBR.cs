using KGarden.Superlist.Domain.Core.Commands;
using KGarden.Superlist.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace KGarden.SuperList.Infra.Data.UoW
{
	public class UnitOfWorkDBR : IUnitOfWorkDBR
	{
		//Implement This
		public Task BeginTransaction()
		{
			throw new NotImplementedException();
		}

		public Task<CommandResponse> Commit()
		{
			throw new NotImplementedException();
		}

		public Task<CommandResponse> CommitTransaction()
		{
			throw new NotImplementedException();
		}

		public Task Rollback()
		{
			throw new NotImplementedException();
		}
	}
}
