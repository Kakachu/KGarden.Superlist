using System;

namespace KGarden.Superlist.Domain.Models
{
	public class Lists
	{
        public Lists()
        {
            
        }

        public string Name { get; protected set; }

        public string? Description { get; protected set; }

        public string Identification { get; protected set; }

        public string Email { get; protected set; }

        public DateTime DateCreated { get; protected set; }

        public DateTime? DateUpdated { get; protected set; }

        public Guid? CategoryId { get; protected set; }
    }
}
