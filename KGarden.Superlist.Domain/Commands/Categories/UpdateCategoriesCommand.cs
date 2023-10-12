using System;

namespace KGarden.Superlist.Domain.Commands.Categories
{
	public class UpdateCategoriesCommand : CategoriesCommand
	{
        public UpdateCategoriesCommand(Guid id, string name, string? description)
        {
			Id = id;
			Name = name;
			Description = description;
        }

		public override bool IsValid()
		{
			return true;
		}
	}
}
