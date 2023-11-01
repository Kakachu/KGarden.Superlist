using KGarden.Superlist.Domain.Commands.Lists;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using KGarden.Superlist.Utils.Common.Date;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.CommandHandlers
{
    public class ListsCommandHandler : CommandDBRHandler,
                                       INotificationHandler<RegisterListsCommand>,
                                       INotificationHandler<UpdateListsCommand>,
                                       INotificationHandler<RemoveListsCommand>
    {
        private readonly IListsRepository _listsRepository;
        private readonly IMediatorHandler _bus;

        public ListsCommandHandler(IListsRepository listsRepository,
                                   IMediatorHandler bus,
                                   IUnitOfWorkDBR uow,
                                   INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _listsRepository = listsRepository;
            _bus = bus;
        }

        public async Task Handle(RegisterListsCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var any = await _listsRepository.AnyByName(message.Name);
            if (any)
            {
                await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe uma Lista atrelada a este nome, será necessário informar outro nome."));
            }

            var list = new Lists(message.Id, message.Name, message.Description, message.Identification, message.Email, DateCommon.DateNowBR(), message.SuperListId, message.CategoryId);

            await _listsRepository.Add(list);
            await Commit();
        }

        public async Task Handle(UpdateListsCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var listExists = await _listsRepository.GetById(message.Id);
            if(listExists == null)
            {
                await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Registro não foi encontrado no banco de dados."));
                return;
            }

            if (string.IsNullOrEmpty(listExists.Identification))
            {
                await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Lista não encontrada ou inválida."));
                return;
            }

            var list = new Lists(listExists, message.Name, message.Description, DateCommon.DateNowBR(), message.CategoryId);

            await _listsRepository.Update(list, list.Id);
            await Commit();
        }

        public async Task Handle(RemoveListsCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var listExists = await _listsRepository.GetById(message.Id);
            if (listExists == null)
            {
                await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Registro não foi encontrado no banco de dados."));
                return;
            }

            _listsRepository.Remove(listExists);
            await Commit();
        }
    }
}
