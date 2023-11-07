using KGarden.Superlist.Domain.Core.Models;
using System;

namespace KGarden.Superlist.Domain.Models
{
	public class ListItems : EntityDBR
	{
		public ListItems()
		{

		}

        public ListItems(Guid id, string productName, decimal? priceUN, decimal? priceTotal, int amount, Guid productId, Guid listId)
        {
            Id = id;
			ProductName = productName;
			PriceUN = priceUN;
			PriceTotal = priceTotal;
			Amount = amount;
			ProductId = productId;
			ListId = listId;
        }

        public string ProductName { get; protected set; }

		public decimal? PriceUN { get; protected set; }

		public decimal? PriceTotal { get; protected set; }

		public int Amount { get; protected set; }

		public Guid ProductId { get; protected set; }

		public Guid ListId { get; protected set; }
	}
}
