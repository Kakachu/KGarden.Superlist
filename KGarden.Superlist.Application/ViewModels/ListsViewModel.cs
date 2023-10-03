using System;

namespace KGarden.Superlist.Application.ViewModels
{
	public class ListsViewModel
	{
        public Guid Id { get; set; }

		public string Name { get; set; }

		public string? Description { get; set; }

		public string Identification { get; set; }

		public string Email { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime? DateUpdated { get; set; }

		public Guid SuperListId { get; set; }

		public Guid? CategoryId { get; set; }
	}
}
