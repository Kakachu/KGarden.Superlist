using KGarden.Superlist.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace KGarden.Superlist.Domain.Models
{
	public class SuperLists : EntityDBR
	{
		public SuperLists()
		{

		}

		public string Name { get; protected set; }

		public string Identification { get; protected set; }

		public string Email { get; protected set; }

		public List<Lists> Lists { get; protected set; }
	}
}
