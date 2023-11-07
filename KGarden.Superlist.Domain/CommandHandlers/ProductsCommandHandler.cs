using KGarden.Superlist.Domain.Commands.Products;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KGarden.Superlist.Domain.CommandHandlers
{
	public class ProductsCommandHandler : CommandDBRHandler,
										  INotificationHandler<RegisterProductsCommand>,
										  INotificationHandler<UpdateProductsCommand>,
										  INotificationHandler<RemoveProductsCommand>
	{
		private readonly IProductsRepository _productsRepository;
		private readonly IMediatorHandler _bus;

		public ProductsCommandHandler(IProductsRepository productsRepository,
									  IMediatorHandler bus,
									  IUnitOfWorkDBR uow,
									  INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
		{
			_productsRepository = productsRepository;
			_bus = bus;
		}

		public async Task Handle(RegisterProductsCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var any = await _productsRepository.GetByProductName(message.Name);
			if (any != null)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe um produto atrelado a este nome, será necessário informar outro nome."));
			}

			var product = new Products(message.Id, message.Name, message.Description, message.Price, message.CategoryId);

			await _productsRepository.Add(product);
			await Commit();
		}

		public async Task Handle(UpdateProductsCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var productExist = await _productsRepository.GetById(message.Id);
			if (productExist == null)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Registro não foi encontrado no banco de dados."));
			}

			var product = new Products(productExist, message.Name, message.Description, message.Price, message.CategoryId);

			await _productsRepository.Update(product, product.Id);
			await Commit();
		}

		public async Task Handle(RemoveProductsCommand message, CancellationToken cancellationToken)
		{
			if (!message.IsValid())
			{
				NotifyValidationErrors(message);
				return;
			}

			var productExist = await _productsRepository.GetById(message.Id);
			if (productExist == null)
			{
				await _bus.RaiseEvent(new DomainNotification(message.MessageType, "Registro não foi encontrado no banco de dados."));
				return;
			}

			_productsRepository.Remove(productExist);
			await Commit();
		}
	}
}

