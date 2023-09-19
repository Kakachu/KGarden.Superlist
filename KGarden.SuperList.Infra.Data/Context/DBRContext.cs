using KGarden.Superlist.Domain.Models;
using KGarden.Superlist.Infra.App.Settings.Interface;
using Microsoft.EntityFrameworkCore;

namespace KGarden.SuperList.Infra.Data.Context
{
	public class DBRContext : DbContext
	{
		private IAppSettings _appSettings;

		public DBRContext(IAppSettings appSettings)
		{
			_appSettings = appSettings;
		}

		public DbSet<SuperLists> SuperLists { get; set; }

		public DbSet<Lists> Lists { get; set; }

		public DbSet<ListItems> ListItems { get; set; }

		public DbSet<Products> Products { get; set; }

		public DbSet<Categories> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_appSettings.GetConnectionString("DefaultConnection"));
		}
	}
}
