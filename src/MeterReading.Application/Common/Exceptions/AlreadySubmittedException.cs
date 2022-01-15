namespace MeterReading.Application.Common.Exceptions
{
    public class AlreadySubmittedException : Exception
    {
        public AlreadySubmittedException() : base() { }

        public AlreadySubmittedException(string message) : base(message) { }

        public AlreadySubmittedException(string message, Exception innerException) : base(message, innerException) { }

        public AlreadySubmittedException(int accountId) : base($"Meter reading for Account {accountId}, has already been submitted") { }
    }
}
