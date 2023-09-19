using KGarden.Superlist.Domain.Core.Models;
using System;

namespace KGarden.Superlist.Domain.Models
{
	public class Products : EntityDBR
	{
        public Products()
        {
            
        }

        public string Name { get; protected set; }

		public string? Description { get; protected set; }

        public decimal? Price { get; protected set; }

        public Guid? CategoryId { get; protected set; }

        public Categories Categories { get; protected set; }
    }
}
