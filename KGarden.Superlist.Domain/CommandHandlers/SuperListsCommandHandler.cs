using KGarden.Superlist.Domain.Commands.SuperLists;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.CommandHandlers
{
	public class SuperListsCommandHandler : CommandDBRHandler,
                                            INotificationHandler<RegisterSuperListsCommand>
	{
        private readonly IMediatorHandler _bus;
        public SuperListsCommandHandler(IMediatorHandler bus,
                                        IUnitOfWorkDBR uow,
                                        INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _bus = bus;
        }

        public async Task Handle(RegisterSuperListsCommand message, CancellationToken cancellationToken)
        {
            
        }
    }

}