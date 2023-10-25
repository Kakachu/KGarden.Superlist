using KGarden.Superlist.Domain.Core.Commands;
using KGarden.Superlist.Domain.Interfaces;
using KGarden.SuperList.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace KGarden.SuperList.Infra.Data.UoW
{
	public class UnitOfWorkDBR : IUnitOfWorkDBR
	{
		private readonly DBRContext _context;
		private IDbContextTransaction _transaction;
        public UnitOfWorkDBR(DBRContext context)
        {
            _context = context;
        }

        public async Task BeginTransaction()
		{
			if (_transaction == null)
			{
				_transaction = await _context.Database.BeginTransactionAsync();
			}
		}

		public async Task<CommandResponse> Commit()
		{
			try
			{
				var rowsAffected = await _context.SaveChangesAsync();

				return new CommandResponse(rowsAffected > 0);
			}
			catch(ValidationException ex)
			{

				var sqlException = ex.GetBaseException() as SqlException;
				return new CommandResponse(false, true, ex?.Message);
			}
			catch (DbUpdateException ex)
			{
				var sqlException = ex.GetBaseException() as SqlException;

				return new CommandResponse(false, true, ex?.InnerException?.Message);
			}
			catch(Exception ex)
			{
				return new CommandResponse(false, true, ex.Message);
			}
		}

		public async Task<CommandResponse> CommitTransaction()
		{
			try
			{
				if (_transaction == null)
				{
					return new CommandResponse(false, false, "You must open a transaction before closing the transaction");
				}

				await _transaction.CommitAsync();

				return new CommandResponse(success: true);
			}
			catch(Exception ex)
			{
				_transaction.Rollback();

				var message = string.Format("CommitTransaction - UnitOfWorkDBR - {0} - {1}", ex.Message, ex.InnerException);
				return new CommandResponse(false, true, message);
			}
		}

		public async Task Rollback()
		{
			if(_transaction != null)
			{
				await _transaction.RollbackAsync();
			}
		}

		public void Dispose()
		{
			if(_transaction != null)
			{
				_transaction.Dispose();
			}

			_context.Dispose();
		}
	}
}
