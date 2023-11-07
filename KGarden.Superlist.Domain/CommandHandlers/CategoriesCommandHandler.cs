using KGarden.Superlist.Domain.Commands.Categories;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using KGarden.Superlist.Utils.Common.Date;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.CommandHandlers
{
	public class CategoriesCommandHandler : CommandDBRHandler,
											INotificationHandler<RegisterCategoriesCommand>,
											INotificationHandler<UpdateCategoriesCommand>
	{
		private readonly ICategoriesRepository _categoriesRepository;
		private readonly IMediatorHandler _bus;

		public CategoriesCommandHandler(ICategoriesRepository categoriesRepository,
										IMediatorHandler bus,
										IUnitOfWorkDBR uow,
										INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)

		{

			_categoriesRepository = categoriesRepository;
			_bus = bus;
		}

        public async Task Handle(RegisterCategoriesCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var any = await _categoriesRepository.AnyByName(message.Name);
			if (any)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe uma Categoria atrelada a este nome, será necessário informar outro nome."));
			}

			var category = new Categories(message.Id, message.Name, message.Description);

			await _categoriesRepository.Add(category);
			await Commit();
		}

		public async Task Handle(UpdateCategoriesCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var categoryExists = await _categoriesRepository.GetById(message.Id);
			if (categoryExists == null)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Registro não foi encontrado no banco de dados."));
				return;
			}

			var category = new Categories(categoryExists, message.Name, message.Description);

			await _categoriesRepository.Update(category, category.Id);
			await Commit();
		}
	}
}
