using StallosDotnetPleno.Domain.Enums;

namespace StallosDotnetPleno.Domain.Models.Logs
{
    public class LogModel : Entity
    {
        public TypeLog Type { get; private set; }
        public string Service { get; private set; }
        public string Message { get; private set; }
        public string StackTrace { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private LogModel(TypeLog type, string message, string stackTrace, string service, DateTime createdAt)
        {
            Service = service;
            Type = type;
            Message = message;
            StackTrace = stackTrace;
            CreatedAt = createdAt;
        }

        public static LogModel New(TypeLog type, string message, string stackTrace, string service, DateTime createdAt)
            => new(type, message, stackTrace, service, createdAt);

    }
}