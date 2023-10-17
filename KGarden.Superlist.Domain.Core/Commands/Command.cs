using FluentValidation.Results;
using KGarden.Superlist.Domain.Core.Events;

namespace KGarden.Superlist.Domain.Core.Commands
{
	public abstract class Command : Message
	{
		public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

		public abstract bool IsValid();
    }
}
