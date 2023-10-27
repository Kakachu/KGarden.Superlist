using KGarden.Superlist.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace KGarden.Superlist.Domain.Models
{
	public class SuperLists : EntityDBR
	{
		public SuperLists(Guid id, string name, string identification, string email)
		{
			Id = id;
			Name = name;
			Identification = identification;
			Email = email;
		}

		public SuperLists(SuperLists _this, string name, string identification, string email)
		{
			Id = _this.Id;
			Name = name;
			Identification = identification;
			Email = email;
		}

		public string Name { get; protected set; }

		public string Identification { get; protected set; }

		public string Email { get; protected set; }

		public List<Lists> Lists { get; protected set; }
	}
}
