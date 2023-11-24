using System;

namespace KGarden.Superlist.Domain.Commands.SuperLists
{
	public class UpdateSuperListsCommand : SuperListsCommand
	{
        public UpdateSuperListsCommand(Guid id, Guid userId, string name, string identification, string email, DateTime dateCreated, DateTime? dateUpdated)
        {
            Id = id;
			UserId = userId;
			Name = name;
			Identification = identification;
			Email = email;
			DateCreated = dateCreated;
			DateUpdated = dateUpdated;
        }

		public override bool IsValid()
		{
			return true;
		}
	}
}
