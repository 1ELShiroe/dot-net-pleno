using StallosDotnetPleno.Application.Interfaces.Services;
using StallosDotnetPleno.Domain.Commons;
using FluentValidation.Results;

namespace StallosDotnetPleno.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public List<Notification> Notifications { get; set; } = [];
        public bool HasNotifications => Notifications.Count != 0;

        public void AddNotification(string key, string message)
            => Notifications.Add(new Notification(key, message));

        public void AddNotifications(ValidationResult validationResult)
        {
            if (validationResult == null) return;

            validationResult.Errors.ForEach(error =>
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            });
        }
    }
}