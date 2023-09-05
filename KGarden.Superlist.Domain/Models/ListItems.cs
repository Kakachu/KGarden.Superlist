namespace KGarden.Superlist.Domain.Models
{
	public class ListItems
	{
        public ListItems()
        {
            
        }

        public string ProductName { get; protected set; }

        public decimal? PriceUN { get; protected set; }

        public decimal? PriceTotal { get; protected set; }

        public int Amount { get; protected set; } = 1;

        public Guid ProductId { get; protected set; }

        public Guid ListId { get; protected set; }
	}
}
