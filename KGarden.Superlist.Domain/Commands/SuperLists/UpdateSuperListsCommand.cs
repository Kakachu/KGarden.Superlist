using System;

namespace KGarden.Superlist.Domain.Commands.SuperLists
{
	public class UpdateSuperListsCommand : SuperListsCommand
	{
        public UpdateSuperListsCommand(Guid id, string name, string identification, string email)
        {
            Id = id;
			Name = name;
			Identification = identification;
			Email = email;
        }

		public override bool IsValid()
		{
			return true;
		}
	}
}
