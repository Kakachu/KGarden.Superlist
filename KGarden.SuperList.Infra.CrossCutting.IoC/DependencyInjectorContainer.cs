using KGarden.Superlist.Domain.Interfaces;
using KGarden.Superlist.Infra.App.Settings.Config;
using KGarden.Superlist.Infra.App.Settings.Interface;
using KGarden.SuperList.Infra.Data.Context;
using KGarden.SuperList.Infra.Data.Repository;
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

			//Infra - Data
			services.AddScoped<IProductsRepository, ProductsRepository>();
			services.AddScoped<IListsRepository, ListsRepository>();
			services.AddScoped<IListItemsRepository, ListItemsRepository>();

			services.AddScoped<DBRContext>();
		}
	}
}
