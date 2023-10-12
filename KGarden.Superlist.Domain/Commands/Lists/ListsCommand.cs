using KGarden.Superlist.Domain.Core.Commands;
using System;

namespace KGarden.Superlist.Domain.Commands.Lists
{
	public abstract class ListsCommand : Command
	{
        public Guid Id { get; protected set; }

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
