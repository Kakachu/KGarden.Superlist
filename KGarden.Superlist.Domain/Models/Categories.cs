using KGarden.Superlist.Domain.Core.Models;
using System;

namespace KGarden.Superlist.Domain.Models
{
	public class Categories : EntityDBR
	{
		public Categories()
		{

		}

		public Categories(Guid id, string name, string? description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		public Categories(Categories _this, string name, string? description)
		{
			Id = _this.Id;
			Name = name;
			Description = description;
		}

		public string Name { get; protected set; }

		public string? Description { get; protected set; }
	}
}
