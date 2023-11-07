using System;

namespace KGarden.Superlist.Domain.Commands.Products
{
	public class RemoveProductsCommand : ProductsCommand
    {
        public RemoveProductsCommand(Guid id)
        {
            Id = id;
        }

		public override bool IsValid()
		{
			return true;
		}
	}
}
