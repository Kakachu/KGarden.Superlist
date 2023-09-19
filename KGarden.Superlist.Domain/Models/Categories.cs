using KGarden.Superlist.Domain.Core.Models;

namespace KGarden.Superlist.Domain.Models
{
	public class Categories : EntityDBR
	{
		public Categories()
		{

		}

		public string Name { get; protected set; }

		public string? Description { get; protected set; }
	}
}
