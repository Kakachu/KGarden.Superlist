using KGarden.Superlist.Domain.Commands.ListItems;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.CommandHandlers
{
	public class ListItemsCommandHandler : CommandDBRHandler,
										   INotificationHandler<RegisterListItemsCommand>,
										   INotificationHandler<RemoveListItemsCommand>
	{
		private readonly IListItemsRepository _listItemsRepository;
		private readonly IMediatorHandler _bus;

		public ListItemsCommandHandler(IListItemsRepository listItemsRepository,
									   IMediatorHandler bus,
									   IUnitOfWorkDBR uow,
									   INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _listItemsRepository = listItemsRepository;
			_bus = bus;
        }

		public async Task Handle(RegisterListItemsCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var listItem = new ListItems(message.Id, message.ProductName, message.PriceUN, message.PriceTotal, message.Amount, message.ProductId, message.ListId);
			await _listItemsRepository.Add(listItem);

			await Commit();
		}

		public async Task Handle(RemoveListItemsCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var listItemExist = await _listItemsRepository.GetById(message.Id);
			if (listItemExist == null)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Registro não foi encontrado no banco de dados."));
				return;
			}

			_listItemsRepository.Remove(listItemExist);
			await Commit();
		}
	}
}
