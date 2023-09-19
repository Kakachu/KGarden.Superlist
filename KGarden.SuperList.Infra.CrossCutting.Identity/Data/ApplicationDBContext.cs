using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace KGarden.SuperList.Infra.CrossCutting.Identity.Data
{
	public class ApplicationDBContext : IdentityDbContext
	{
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            :base (options)
        {          
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//get the configuration from the appsettings

			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			// defines the database to use
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("appsetting.json"));

		}
	}
}
