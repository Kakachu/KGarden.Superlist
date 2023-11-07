using System;

namespace KGarden.Superlist.Domain.Commands.ListItems
{
	public class RegisterListItemsCommand : ListItemsCommand
	{
		public RegisterListItemsCommand(Guid id, string productName, decimal? priceUN, decimal? priceTotal, int amount, Guid productId, Guid listId)
		{
			Id = id;
			ProductName = productName;
			PriceUN = priceUN;
			PriceTotal = priceTotal;
			Amount = amount;
			ProductId = productId;
			ListId = listId;
		}

		public override bool IsValid()
		{
			return true;
		}
	}
}
