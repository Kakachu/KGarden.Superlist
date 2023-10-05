using System;

namespace KGarden.Superlist.Domain.Commands.Products
{
	public class ProductsRegisterCommand : ProductsCommand
    {
        public ProductsRegisterCommand(Guid id, string name, string description, decimal? price, Guid? categoryId)
        {
            Id  = id;
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
