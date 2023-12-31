﻿using KGarden.SuperList.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KGarden.Superlist.Web.UI.Configurations
{
	public static class DependencyInjectionConfiguration
	{
		public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IWebHostEnvironment environment)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			DependencyInjectorContainer.RegisterServices(services, environment);
		}
	}
}
