using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace DataWrangler
{
    class NotificationHelper
    {
        private static string NotificationTitle = "Data Wrangler";

        public enum NotificationType
        {
            Information,
            Warning,
            Error
        }

        public static void ShowNotification(MetroForm parentForm, NotificationType type, string message)
        {
            string title = NotificationTitle + " - " + type;
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
            MetroMessageBox.Show(parentForm, message, title, MessageBoxButtons.OK, boxStyle);
        }
    }
}
