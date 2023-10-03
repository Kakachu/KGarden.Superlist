using KGarden.Superlist.Domain.Models;
using System;

namespace KGarden.Superlist.Application.ViewModels
{
	public class ProductsViewModel
	{
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
