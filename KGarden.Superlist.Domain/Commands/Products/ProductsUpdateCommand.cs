using System;

namespace KGarden.Superlist.Domain.Commands.Products
{
	public class ProductsUpdateCommand : ProductsCommand
    {
        public ProductsUpdateCommand(Guid id, string name, string description, decimal? price, Guid? categoryId)
        {
			Id = id;
			Name = name;
			Description = description;
			Price = price;
			CategoryId = categoryId;
		}

		public override bool IsValid()
		{
			return true;
		}
	}
}
