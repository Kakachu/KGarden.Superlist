using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGarden.Superlist.Application.ViewModels
{
	public class SuperListsViewModel
	{
        public Guid Id { get; set; }

        public string Name { get; set; }

		public string Identification { get; set; }

		public string Email { get; set; }

		public List<ListsViewModel> Lists { get; set; }
	}
}
