using System;

namespace KGarden.Superlist.Domain.Commands.ListItems
{
	public class RemoveListItemsCommand : ListItemsCommand
	{
        public RemoveListItemsCommand(Guid id)
        {
            Id = id;
        }

		public override bool IsValid()
		{
			return true;
		}
	}
}
