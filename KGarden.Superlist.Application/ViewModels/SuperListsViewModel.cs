using System;
using System.Collections.Generic;

namespace KGarden.Superlist.Application.ViewModels
{
	public class SuperListsViewModel
	{
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

		public string Name { get; set; }

		public string Identification { get; set; }

		public string Email { get; set; }

		public DateTime DateCreated { get; set; }

		public DateTime? DateUpdated { get; set; }
	}
}
