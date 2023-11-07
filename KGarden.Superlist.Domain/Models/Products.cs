using KGarden.Superlist.Domain.Core.Models;
using System;

namespace KGarden.Superlist.Domain.Models
{
	public class Products : EntityDBR
	{
        public Products()
        {
            
        }

        public Products(Guid id, string name, string? description, decimal? price, Guid? categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

		public Products(Products _this, string name, string? description, decimal? price, Guid? categoryId)
		{
            Id = _this.Id;
			Name = name;
			Description = description;
			Price = price;
			CategoryId = categoryId;
		}

		public string Name { get; protected set; }

		public string? Description { get; protected set; }

        public decimal? Price { get; protected set; }

        public Guid? CategoryId { get; protected set; }

        public virtual Categories Categories { get; protected set; }
    }
}
