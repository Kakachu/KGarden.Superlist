using KGarden.Superlist.Domain.Core.Commands;
using System;

namespace KGarden.Superlist.Domain.Commands.Categories
{
	public abstract class CategoriesCommand : Command
	{
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string? Description { get; protected set; }
	}
}
