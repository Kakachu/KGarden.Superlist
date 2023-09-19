using System;

namespace KGarden.Superlist.Infra.App.Settings.Interface
{
	public interface IAppSettings : IDisposable
	{
		public string GetConnectionString(string connection);
	}
}
