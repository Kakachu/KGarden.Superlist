using System;

namespace KGarden.Superlist.Domain.Commands.Lists
{
	public class RemoveListsCommand : ListsCommand
	{
		public RemoveListsCommand(Guid id)
		{
			Id = id;
		}

		public override bool IsValid()
		{
			return true;
		}
	}
}
