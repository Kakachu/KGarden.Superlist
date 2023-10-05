using System;

namespace KGarden.Superlist.Domain.Commands.Products
{
	public class ProductsRemoveCommand : ProductsCommand
    {
        public ProductsRemoveCommand(Guid id)
        {
            Id = id;
        }

		public override bool IsValid()
		{
			return true;
		}
	}
}
