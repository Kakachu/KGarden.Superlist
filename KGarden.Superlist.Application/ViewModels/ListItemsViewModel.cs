using System;

namespace KGarden.Superlist.Application.ViewModels
{
	public class ListItemsViewModel
	{
        public Guid Id { get; set; }

        public string ProductName { get; set; }

		public decimal? PriceUN { get; set; }

		public decimal? PriceTotal { get; set; }

		public int Amount { get; set; } = 1;

		public Guid ProductId { get; set; }

		public Guid ListId { get; set; }
	}
}
