using KGarden.Superlist.Infra.App.Settings.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace KGarden.Superlist.Infra.App.Settings.Config
{
	public class AppSettings : IAppSettings
	{
        public IConfigurationRoot _configuration; 

		public AppSettings(string rootPath, string environmentName)
		{
			var configObj = new ConfigurationBuilder()
				 .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
				 .AddJsonFile("appsettings.json");

			if (!string.IsNullOrEmpty(environmentName))
			{
				configObj.AddJsonFile($"appsettings.{environmentName}.json", optional: false);
			}

			_configuration = configObj.AddEnvironmentVariables().Build();
		}

		public string GetConnectionString(string connection)
		{
			return _configuration.GetConnectionString(connection);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
