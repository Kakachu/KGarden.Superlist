using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Commands;
using KGarden.Superlist.Domain.Core.Events;
using MediatR;

namespace KGarden.SuperList.Infra.CrossCutting.Bus
{
	public sealed class InMemoryBus : IMediatorHandler
	{
		private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

		public Task SendCommand<T>(T command) where T : Command
		{
			return Publish(command);
		}

		public Task RaiseEvent<T>(T @event, string username = null) where T : Event
		{
			if (!@event.MessageType.Equals("DomainNotification"))
			{
			}
			return Publish(@event);
		}

		private Task Publish<T>(T message) where T : Message
		{
			return _mediator.Publish(message);
		}
	}
}
