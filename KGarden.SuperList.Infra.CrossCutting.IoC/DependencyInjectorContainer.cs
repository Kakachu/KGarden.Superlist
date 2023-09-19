using KGarden.Superlist.Infra.App.Settings.Config;
using KGarden.Superlist.Infra.App.Settings.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace KGarden.SuperList.Infra.CrossCutting.IoC
{
	public class DependencyInjectorContainer
	{
		public static void RegisterServices(IServiceCollection services, IWebHostEnvironment environment)
		{
			var appSettings = new AppSettings(environment.ContentRootPath, environment.EnvironmentName);

			services.AddScoped<IAppSettings>(x => appSettings);
		}
	}
}
