using System;

namespace KGarden.Superlist.Domain.Commands.SuperLists
{
	public class RegisterSuperListsCommand : SuperListsCommand
	{
        public RegisterSuperListsCommand(Guid id, string name, string identification, string email, DateTime dateCreated)
        {
            Id = id;
			Name = name;
			Identification = identification;
			Email = email;
			DateCreated = dateCreated;
        }

		public override bool IsValid()
		{
			return true;
		}
	}
}
