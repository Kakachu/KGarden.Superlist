using KGarden.Superlist.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KGarden.Superlist.Web.UI.Configurations
{
	public static class AutoMapperConfig
	{
		public static void AutoMapperConfiguration(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddAutoMapper(typeof(DomainToViewModelProfile), typeof(ViewModelToDomainProfile));
		}
	}
}
