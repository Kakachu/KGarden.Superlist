namespace KGarden.Superlist.Domain.Core.Commands
{
	public class CommandResponse
	{
        public CommandResponse(bool success = false, bool isException = false, string message = null)
        {
            Success = success;
            IsException = isException;
            Message = message;
        }

        public bool Success { get; private set; }

        public bool IsException { get; private set; }

        public string Message { get; private set; }
    }
}
