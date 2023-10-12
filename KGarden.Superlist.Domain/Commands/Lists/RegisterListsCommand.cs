using System;

namespace KGarden.Superlist.Domain.Commands.Lists
{
	public class RegisterListsCommand : ListsCommand
	{
		public RegisterListsCommand(Guid id, string name, string? description, string identification, string email, DateTime dateCreated, DateTime? dateUpdated, Guid superListId, Guid? categoryId)
		{
			Id = id;
			Name = name;
			Description = description;
			Identification = identification;
			Email = email;
			DateCreated = dateCreated;
			DateUpdated = dateUpdated;
			SuperListId = superListId;
			CategoryId = categoryId;
		}

		public override bool IsValid()
		{
			return true;
		}
	}
}
