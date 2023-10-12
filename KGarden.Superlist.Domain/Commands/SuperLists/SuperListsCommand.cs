﻿using KGarden.Superlist.Domain.Core.Commands;
using System;

namespace KGarden.Superlist.Domain.Commands.SuperLists
{
	public abstract class SuperListsCommand : Command
	{
		public Guid Id { get; protected set; }

		public string Name { get; protected set; }

		public string Identification { get; protected set; }

		public string Email { get; protected set; }
	}
}
