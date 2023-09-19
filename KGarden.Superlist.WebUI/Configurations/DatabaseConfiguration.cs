﻿using KGarden.SuperList.Infra.CrossCutting.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace KGarden.Superlist.Web.UI.Configurations
{
	public static class DatabaseConfiguration
	{
		public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			if(services == null) throw new ArgumentNullException(nameof(services));

			services.AddDbContext<ApplicationDBContext>(
				options => options.UseSqlServer("DefaultConnection"));
		}
	}
}
