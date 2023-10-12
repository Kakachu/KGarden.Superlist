using System;

namespace KGarden.Superlist.Domain.Commands.SuperLists
{
	public class RemoveSuperListsCommand : SuperListsCommand
	{
        public RemoveSuperListsCommand(Guid id)
        {
            Id = id;
        }

		public override bool IsValid()
		{
			return true;
		}
	}
}
