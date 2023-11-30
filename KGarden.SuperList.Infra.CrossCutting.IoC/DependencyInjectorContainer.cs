using AutoMapper;
using KGarden.Superlist.Application.Interfaces;
using KGarden.Superlist.Application.Services;
using KGarden.Superlist.Domain.CommandHandlers;
using KGarden.Superlist.Domain.Commands.Categories;
using KGarden.Superlist.Domain.Commands.ListItems;
using KGarden.Superlist.Domain.Commands.Lists;
using KGarden.Superlist.Domain.Commands.Products;
using KGarden.Superlist.Domain.Commands.SuperLists;
using KGarden.Superlist.Domain.Core.Bus;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Infra.App.Settings.Config;
using KGarden.Superlist.Infra.App.Settings.Interface;
using KGarden.SuperList.Infra.CrossCutting.Bus;
using KGarden.SuperList.Infra.Data.Context;
using KGarden.SuperList.Infra.Data.Repository;
using KGarden.SuperList.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KGarden.SuperList.Infra.CrossCutting.IoC
{
	public class DependencyInjectorContainer
	{
		public static void RegisterServices(IServiceCollection services, IWebHostEnvironment environment)
		{
			var appSettings = new AppSettings(environment.ContentRootPath, environment.EnvironmentName);

			//ASP.NET HttpContext dependency
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			// Domain Bus (Mediator)
			services.AddScoped<IMediatorHandler, InMemoryBus>();

			//Infra - AppSettings
			services.AddScoped<IAppSettings>(x => appSettings);

			//Application
			services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

			services.AddScoped<ICategoriesAppService, CategoriesAppService>();
			services.AddScoped<IListItemsAppService, ListItemsAppService>();
			services.AddScoped<IListsAppService, ListsAppService>();
			services.AddScoped<IProductsAppService, ProductsAppService>();
			services.AddScoped<ISuperListsAppService, SuperListsAppService>();

			//Domain - Commands
			services.AddScoped<INotificationHandler<RegisterSuperListsCommand>, SuperListsCommandHandler>();
			services.AddScoped<INotificationHandler<UpdateSuperListsCommand>, SuperListsCommandHandler>();
			services.AddScoped<INotificationHandler<RemoveSuperListsCommand>, SuperListsCommandHandler>();

			services.AddScoped<INotificationHandler<RegisterListsCommand>, ListsCommandHandler>();
			services.AddScoped<INotificationHandler<UpdateListsCommand>, ListsCommandHandler>();
			services.AddScoped<INotificationHandler<RemoveListsCommand>, ListsCommandHandler>();

			services.AddScoped<INotificationHandler<RegisterListItemsCommand>, ListItemsCommandHandler>();
			services.AddScoped<INotificationHandler<RemoveListItemsCommand>, ListItemsCommandHandler>();

			services.AddScoped<INotificationHandler<RegisterProductsCommand>, ProductsCommandHandler>();
			services.AddScoped<INotificationHandler<UpdateProductsCommand>, ProductsCommandHandler>();
			services.AddScoped<INotificationHandler<RemoveProductsCommand>, ProductsCommandHandler>();

			services.AddScoped<INotificationHandler<RegisterCategoriesCommand>, CategoriesCommandHandler>();
			services.AddScoped<INotificationHandler<UpdateCategoriesCommand>, CategoriesCommandHandler>();

			//Domain - Events
			services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

			//Infra - Data
			services.AddScoped<IProductsRepository, ProductsRepository>();
			services.AddScoped<IListsRepository, ListsRepository>();
			services.AddScoped<IListItemsRepository, ListItemsRepository>();
			services.AddScoped<ISuperListsRepository, SuperListsRepository>();
			services.AddScoped<IProductsRepository, ProductsRepository>();
			services.AddScoped<ICategoriesRepository, CategoriesRepository>();

			services.AddScoped<IUnitOfWorkDBR, UnitOfWorkDBR>();

			services.AddScoped<DBRContext>();
		}
	}
}
