using KGarden.Superlist.Domain.Core.Commands;
using System;

namespace KGarden.Superlist.Domain.Commands.ListItems
{
	public abstract class ListItemsCommand : Command
	{
        public Guid Id { get; protected set; }

        public string ProductName { get; protected set; }

        public decimal? PriceUN { get; protected set; }

        public decimal? PriceTotal { get; protected set; }

		public int Amount { get; protected set; }

		public Guid ProductId { get; protected set; }

		public Guid ListId { get; protected set; }
	}
}
