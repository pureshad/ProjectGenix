using Genix.Services.Services.Messages;
using System;

namespace Genix.Services.Infrastructure.Messages
{
    public interface INotificationService
    {
        void Notification(NotifyType notifyType, string message, bool encode = true);
        void SuccessNotification(string message, bool encode = true);
        void WarningNotification(string message, bool encode = true);
        void ErrorNotification(string message, bool encode = true);
        void ErrorExceptionNotification(Exception exception, bool logException = true);

    }
}
