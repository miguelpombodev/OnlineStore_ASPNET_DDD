namespace OnlineStore.Services.Errors
{
    public class ServiceError : Exception
    {
        public ServiceError(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public ServiceError(string message, int statusCode, string? logExceptionMessage)
        {
            Message = message;
            StatusCode = statusCode;
            LogExceptionMessage = logExceptionMessage;

            if (logExceptionMessage != null) LogMessageError(logExceptionMessage);
        }

        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string? LogExceptionMessage { get; set; }

        private void LogMessageError(string logExceptionMessage)
        {
            Console.WriteLine($"ERROR MESSAGE - ${logExceptionMessage}");
        }
    }
}