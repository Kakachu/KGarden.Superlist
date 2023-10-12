using System;

namespace KGarden.Superlist.Domain.Commands.Categories
{
	public class RegisterCategoriesCommand : CategoriesCommand
	{
        public RegisterCategoriesCommand(Guid id, string name, string? description )
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
