using System;

namespace KGarden.Superlist.Domain.Models
{
	public class SuperLists
	{
        public SuperLists()
        {
            
        }

        public string Name { get; protected set; }

        public string Identification { get; protected set; }

        public string Email { get; protected set; }

        public Guid? ListId { get; protected set; }

        public Lists Lists { get; protected set; }
    }
}
