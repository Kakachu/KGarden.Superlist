using KGarden.Superlist.Web.UI.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Reflection;

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

			services.AddDatabaseDeveloperPageExceptionFilter();

			//DBContexts Settings
			services.AddDataBaseConfiguration(Configuration);

			//AutoMapper
			services.AutoMapperConfiguration();

			// Adding MediatR for Domain Events and Notifications
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			// .NET Native DI Abstraction
			services.AddDependencyInjectionConfiguration(WebHostEnvironment);
		}

		public void Configure(IApplicationBuilder app,
						      IWebHostEnvironment enviroment)
		{
			CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
			CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

			if (enviroment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.Use(async (context, next) =>
			{
				context.Response.Headers.Add("X-Frame-Options", "DENY");
				await next();
			});

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseWebSockets();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
