using KGarden.Superlist.Domain.Core.Models;
using System;

namespace KGarden.Superlist.Domain.Models
{
	public class Lists : EntityDBR
	{
		public Lists()
		{

		}

        public Lists(Guid id, string name, string? description, string identification, string email, DateTime dateCreated, Guid superListId, Guid? categoryId)
        {
            Id = id;
			Name = name;
			Description = description;
			Identification = identification;
			Email = email;
			DateCreated = dateCreated;
			SuperListId = superListId;
			CategoryId = categoryId;
        }

        public Lists(Lists _this, string name, string? description, DateTime? dateUpdated, Guid? categoryId)
        {
            Id = _this.Id;
            Name = name;
            Description = description;
            Identification = _this.Identification;
            Email = _this.Identification;
            DateCreated = _this.DateCreated;
            DateUpdated = dateUpdated;
            SuperListId = _this.SuperListId;
            CategoryId = categoryId;
        }

        public string Name { get; protected set; }

		public string? Description { get; protected set; }

		public string Identification { get; protected set; }

		public string Email { get; protected set; }

		public DateTime DateCreated { get; protected set; }

		public DateTime? DateUpdated { get; protected set; }

		public Guid SuperListId { get; protected set; }

		public Guid? CategoryId { get; protected set; }
	}
}
