using KGarden.Superlist.Domain.Core.Models;
using System;

namespace KGarden.Superlist.Domain.Models
{
	public class SuperLists : EntityDBR
	{
		public SuperLists(Guid id, Guid userId, string name, string identification, string email, DateTime dateCreated)
		{
			Id = id;
			UserId = userId;
			Name = name;
			Identification = identification;
			Email = email;
			DateCreated = dateCreated;
		}

		public SuperLists(SuperLists _this, string name, string identification, string email, DateTime? dateUpdated)
		{
			Id = _this.Id;
			UserId = _this.UserId;
			Name = name;
			Identification = identification;
			Email = email;
			DateCreated = _this.DateCreated;
			DateUpdated = dateUpdated;
		}

		public Guid UserId { get; protected set; }

		public string Name { get; protected set; }

		public string Identification { get; protected set; }

		public string Email { get; protected set; }

		public DateTime DateCreated { get; protected set; }

		public DateTime? DateUpdated { get; protected set; }
	}
}
