using KGarden.Superlist.Domain.Core.Commands;
using System;

namespace KGarden.Superlist.Domain.Commands.Products
{
	public abstract class ProductsCommand : Command
    {
        public Guid Id { get; protected set; }

		public string Name { get; protected set; }

		public string Description { get; protected set; }

		public decimal? Price { get; protected set; }

		public Guid? CategoryId { get; protected set; }
	}
}
