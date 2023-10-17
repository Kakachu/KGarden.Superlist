using KGarden.Superlist.Domain.Core.Commands;
using KGarden.Superlist.Domain.Core.Events;

namespace KGarden.Superlist.Domain.Core.Bus
{
	public interface IMediatorHandler
	{
		Task SendCommand<T>(T command) where T : Command;
		Task RaiseEvent<T>(T @event, string username = null) where T : Event;
	}
}
