using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace Windows_Notification_API.Util
{
  public static class ToastSender
  {
    public static void SendToast(string messageBody)
    {
      var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);

      var textNodes = template.GetElementsByTagName("text");
      textNodes.Item(0).InnerText = $"{(DateTime.Now.Hour > 9 ? DateTime.Now.Hour.ToString() : "0" + DateTime.Now.Hour.ToString()) }:{(DateTime.Now.Minute > 9 ? DateTime.Now.Minute.ToString() : "0"+ DateTime.Now.Minute.ToString()) }";
      textNodes.Item(0).InnerText += "\n\n" + messageBody;

      var notifier = ToastNotificationManager.CreateToastNotifier("Windows Notification API");
      var notification = new ToastNotification(template);
      notifier.Show(notification);
    }
  }
}
