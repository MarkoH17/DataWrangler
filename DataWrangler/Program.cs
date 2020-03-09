using System;
using System.Windows.Forms;
using DataWrangler.Forms;

namespace DataWrangler
{
    internal static class Program
    {
        public static ApplicationContext AppContext { get; set; }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppContext = new ApplicationContext(new Welcome());

            Application.Run(AppContext);
        }

        public static void SwitchForm(Form newForm)
        {
            var oldForm = AppContext.MainForm;
            AppContext.MainForm = newForm;
            oldForm?.Close();
            newForm.Show();
        }
    }
}