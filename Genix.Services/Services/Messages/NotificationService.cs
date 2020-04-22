using Genix.Services.Infrastructure.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Genix.Services.Services.Messages
{
    public class NotificationService : INotificationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;

        public NotificationService(IHttpContextAccessor httpContextAccessor,
            ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
        }

        protected void PrepareTempData(NotifyType type, string message, bool encode = true)
        {
            var context = _httpContextAccessor.HttpContext;
            var tempData = _tempDataDictionaryFactory.GetTempData(context);

            var messages = tempData.ContainsKey(GenixMessageDefaults.NotificationKey) ?
                JsonConvert.DeserializeObject<IList<NotifyData>>(tempData[GenixMessageDefaults.NotificationKey].ToString()) :
                new List<NotifyData>();

            messages.Add(new NotifyData()
            {
                Message = message,
                Encode = encode,
                NotifyType = type
            });

            tempData[GenixMessageDefaults.NotificationKey] = JsonConvert.SerializeObject(messages);
        }

        public void ErrorExceptionNotification(Exception exception, bool logException = true)
        {

        }

        public void ErrorNotification(string message, bool encode = true)
        {
            PrepareTempData(NotifyType.Error, message, encode);
        }

        public void Notification(NotifyType notifyType, string message, bool encode = true)
        {
            PrepareTempData(notifyType, message, encode);
        }

        public void SuccessNotification(string message, bool encode = true)
        {
            PrepareTempData(NotifyType.Success, message, encode);
        }

        public void WarningNotification(string message, bool encode = true)
        {
            PrepareTempData(NotifyType.Warning, message, encode);
        }
    }
}
