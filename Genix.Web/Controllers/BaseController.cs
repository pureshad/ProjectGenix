using Genix.Core.Domain.Notification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Genix.Web.Controllers
{
    public abstract partial class BaseController : Controller
    {
        private string _notification;
        private NotificationType _notificationType;

        protected void AddNotification(NotificationType notificationType, string message)
        {
            _notificationType = notificationType;
            _notification = message;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!string.IsNullOrWhiteSpace(_notification) && !string.IsNullOrWhiteSpace(_notificationType.ToString()))
            {
                Controller controller = context.Controller as Controller;
                switch (_notificationType)
                {
                    case NotificationType.RegisterSuccess:
                        controller.ViewData.Add(nameof(NotificationType.RegisterSuccess), _notification);
                        break;
                    case NotificationType.RegisterError:
                        controller.ViewData.Add(nameof(NotificationType.RegisterError), _notification);
                        break;
                    case NotificationType.LoginSuccess:
                        controller.ViewData.Add(nameof(NotificationType.LoginSuccess), _notification);
                        break;
                    case NotificationType.LoginError:
                        controller.ViewData.Add(nameof(NotificationType.LoginError), _notification);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
