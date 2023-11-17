using KGarden.Superlist.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace KGarden.Superlist.Domain.Models
{
	public class SuperLists : EntityDBR
	{
		public SuperLists(Guid id, string name, string identification, string email, DateTime dateCreated, Guid userId)
		{
			Id = id;
			Name = name;
			Identification = identification;
			Email = email;
			DateCreated = dateCreated;
			UserId = userId;
		}

		public SuperLists(SuperLists _this, string name, string identification, string email, DateTime? dateUpdated, Guid userId)
		{
			Id = _this.Id;
			Name = name;
			Identification = identification;
			Email = email;
			DateCreated = _this.DateCreated;
			DateUpdated = dateUpdated;
			UserId = userId;
		}

		public string Name { get; protected set; }

		public string Identification { get; protected set; }

		public string Email { get; protected set; }

		public DateTime DateCreated { get; protected set; }

		public DateTime? DateUpdated { get; protected set; }

		public Guid UserId { get; protected set; }
	}
}
