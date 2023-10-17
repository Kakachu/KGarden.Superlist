using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Commands;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.CommandHandlers
{
	public class CommandDBRHandler
	{
		private readonly IUnitOfWorkDBR _uow;
		private readonly IMediatorHandler _bus;
		private readonly DomainNotificationHandler _notifications;

		public CommandDBRHandler(IUnitOfWorkDBR uow,
								 IMediatorHandler bus,
								 INotificationHandler<DomainNotification> notifications)
		{
			_uow = uow;
			_bus = bus;
			_notifications = (DomainNotificationHandler)notifications;
		}

		protected void NotifyValidationErrors(Command message)
		{
			foreach (var error in message.ValidationResult.Errors)
			{
				_bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
			}
		}

		public async Task BeginTransaction()
		{
			await _uow.BeginTransaction();
		}

		public async Task<bool> Commit()
		{
			if (_notifications.HasNotifications())
			{
				return false;
			}

			var commandResponse = await _uow.Commit();
			if (commandResponse.Success)
			{
				return true;
			}

			if (!string.IsNullOrEmpty(commandResponse.Message))
			{
				//Add Log
				return false;
			}

			if (commandResponse.IsException)
			{
				await _bus.RaiseEvent(new DomainNotification("Commit", string.Format("Detalhes : {0}", commandResponse.Message)));
			}

			return false;
		}

		public async Task<CommandResponse> CommitTransaction()
		{
			return await _uow.CommitTransaction();
		}

		public async Task Rollback()
		{
			await _uow.Rollback();
		}
	}
}
