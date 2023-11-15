using KGarden.Superlist.Web.UI.Configurations;
using KGarden.WebUI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KGarden.Superlist.Web.UI
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment environment) 
		{
			Configuration = configuration;
			WebHostEnvironment = environment;
		}

        public IConfiguration Configuration { get; }

		public IWebHostEnvironment WebHostEnvironment { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			//MVC Settings
			services.AddControllersWithViews();

			services.AddHttpContextAccessor();

			services.AddRazorPages();

			services.AddMemoryCache();

			//DBContexts Settings
			services.AddDataBaseConfiguration(Configuration);

			services.AddDependencyInjectionConfiguration(WebHostEnvironment);

			//AutoMapper
			services.AddAutoMapperConfiguration();
		}
    }
}
