using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace DataWrangler
{
    internal class NotificationHelper
    {
        public enum NotificationType
        {
            Information,
            Warning,
            Error
        }

        private static readonly string NotificationTitle = "Data Wrangler";

        public static DialogResult ShowNotification(MetroForm parentForm, NotificationType type, string message, MessageBoxButtons notificationButtons = MessageBoxButtons.OK)
        {
            var title = NotificationTitle + " - " + type;
            MessageBoxIcon boxStyle;
            switch (type)
            {
                case NotificationType.Information:
                    boxStyle = MessageBoxIcon.Information;
                    break;
                case NotificationType.Warning:
                    boxStyle = MessageBoxIcon.Warning;
                    break;
                case NotificationType.Error:
                    boxStyle = MessageBoxIcon.Error;
                    break;
                default:
                    boxStyle = MessageBoxIcon.Information;
                    break;
            }

            return MetroMessageBox.Show(parentForm, message, title, notificationButtons, boxStyle);
        }
    }
}