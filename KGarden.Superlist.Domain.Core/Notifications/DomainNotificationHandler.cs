using MediatR;

namespace KGarden.Superlist.Domain.Core.Notifications
{
	public class DomainNotificationHandler : INotificationHandler<DomainNotification>
	{
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

		public async Task Handle(DomainNotification notification, CancellationToken cancellationToken)
		{
			_notifications.Add(notification);
			await Task.CompletedTask;
		}

		public virtual List<DomainNotification> GetNotifications()
		{
			return _notifications;
		}

		public virtual bool HasNotifications()
		{
			return GetNotifications().Any();
		} 
		
		public void Dispose()
		{
			_notifications = new List<DomainNotification>();
		}
	}
}
