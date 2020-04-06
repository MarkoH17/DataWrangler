using System;
using System.Windows.Forms;
using DataWrangler.Forms;

namespace DataWrangler
{
    internal static class Program
    {
        private static ApplicationContext AppContext { get; set; }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        ///
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppContext = new ApplicationContext(new Welcome());
            Application.Run(AppContext);
        }

        public static void SwitchPrimaryForm(Form newForm, bool followOldLocation = true)
        {
            var oldForm = AppContext.MainForm;
            AppContext.MainForm = newForm;

            var oldLocation = oldForm.Location;

            oldForm?.Close();
            newForm.Show();

            if (followOldLocation)
            {
                newForm.Location = oldLocation;
            }
        }
    }
}