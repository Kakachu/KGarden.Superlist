﻿using KGarden.Superlist.Application.Interfaces;
using KGarden.Superlist.Domain.CommandHandlers;
using KGarden.Superlist.Domain.Commands.SuperLists;
using KGarden.Superlist.Domain.Core.Notifications;
using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Infra.App.Settings.Config;
using KGarden.Superlist.Infra.App.Settings.Interface;
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

			//Infra - AppSettings
			services.AddScoped<IAppSettings>(x => appSettings);

			//Application

			//Domain - Commands
			services.AddScoped<INotificationHandler<RegisterSuperListsCommand>, SuperListsCommandHandler>();
			services.AddScoped<INotificationHandler<UpdateSuperListsCommand>, SuperListsCommandHandler>();
			services.AddScoped<INotificationHandler<RemoveSuperListsCommand>, SuperListsCommandHandler>();

			//Domain - Events
			services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

			//Infra - Data
			services.AddScoped<IProductsRepository, ProductsRepository>();
			services.AddScoped<IListsRepository, ListsRepository>();
			services.AddScoped<IListItemsRepository, ListItemsRepository>();

			services.AddScoped<IUnitOfWorkDBR, UnitOfWorkDBR>();

			services.AddScoped<DBRContext>();
		}
	}
}
