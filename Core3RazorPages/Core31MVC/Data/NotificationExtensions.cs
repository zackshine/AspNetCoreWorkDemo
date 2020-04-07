using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core31MVC.Data
{
    public static class NotificationExtensions
    {
        private const String NotificationsKey = "Notifications";

        public static void AddNotification(this Controller controller, String message)
        {
            //ICollection<String> messages = controller.TempData[NotificationsKey] as ICollection<String>;
            //if (messages == null)
            //{
            //    controller.TempData[NotificationsKey] = (messages = new HashSet<String>());
            //}
            //messages.Add(message);

            ICollection<string> messages = controller.TempData[NotificationsKey] as ICollection<string>;
            if (messages == null)
                controller.TempData[NotificationsKey] = (messages = new HashSet<string>());
            KeyValuePair<string, string> keyValuePair = new KeyValuePair<string, string>("test", message);
            var keyValuePair2 = new KeyValuePair<string, string>("test2", message);

            string serializedObject = JsonConvert.SerializeObject(keyValuePair, Formatting.None);
            string serializedObject2 = JsonConvert.SerializeObject(keyValuePair2, Formatting.None);
            try
            {
                messages.Add(serializedObject);
                messages.Add(serializedObject2);
            }
            catch { }
        }

        public static IEnumerable<String> GetNotifications(this HtmlHelper htmlHelper)
        {
            return htmlHelper.ViewContext.TempData[NotificationsKey] as ICollection<String> ?? new HashSet<String>();
        }
    }
}
