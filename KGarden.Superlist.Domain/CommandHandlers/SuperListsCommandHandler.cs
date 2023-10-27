using KGarden.Superlist.Domain.Commands.SuperLists;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.CommandHandlers
{
	public class SuperListsCommandHandler : CommandDBRHandler,
											INotificationHandler<RegisterSuperListsCommand>,
											INotificationHandler<UpdateSuperListsCommand>,
											INotificationHandler<RemoveSuperListsCommand>
	{
		private readonly ISuperListsRepository _superListRepository;
		private readonly IMediatorHandler _bus;

		public SuperListsCommandHandler(ISuperListsRepository superListsRepository,
										IMediatorHandler bus,
										IUnitOfWorkDBR uow,
										INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
		{
			_superListRepository = superListsRepository;
			_bus = bus;
		}

		public async Task Handle(RegisterSuperListsCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var any = await _superListRepository.AnySuperListByName(message.Name);
			if(any)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe uma SuperLista atrelada a este nome, será necessário informar outro nome."));
			}

			var superList = new SuperLists(message.Id, message.Name, message.Identification, message.Email);

			await _superListRepository.Add(superList);

			await Commit();
		}

		public async Task Handle(UpdateSuperListsCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var superListExist = await _superListRepository.GetById(message.Id);
			if(superListExist == null)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Registro não foi encontrado no banco de dados."));
				return;
			}

			if (string.IsNullOrEmpty(superListExist.Identification))
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "SuperLista não encontrada ou inválida."));
				return;
			}

			var superList = new SuperLists(superListExist, message.Name, message.Identification, message.Email);
			await _superListRepository.Update(superList, superList.Id);

			await Commit();
		}

		public async Task Handle(RemoveSuperListsCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var superListExist = await _superListRepository.GetById(message.Id);
			if (superListExist == null)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Registro não foi encontrado no banco de dados."));
				return;
			}

			_superListRepository.Remove(superListExist);
			await Commit();
		}
	}

}