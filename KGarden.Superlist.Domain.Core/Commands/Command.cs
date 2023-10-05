using System.ComponentModel.DataAnnotations;

namespace KGarden.Superlist.Domain.Core.Commands
{
	public abstract class Command
	{
		public DateTime Timestamp { get; private set; }

        public ValidationResult ValidationResult { get; set; }

		public abstract bool IsValid();
    }
}
