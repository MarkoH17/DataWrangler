using System;
using System.Configuration;
using System.Windows.Forms;C:\Users\aj.skilling\Source\Repos\CIS432-SeniorProject\DataWrangler\Program.cs
using DataWrangler.Forms;

namespace DataWrangler
{
    internal static class Program
    {
        private static ApplicationContext _appContext { get; set; }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _appContext = new ApplicationContext(new Welcome());
            Application.Run(_appContext);
        }

        public static void SwitchForm(Form newForm)
        {
            var oldForm = _appContext.MainForm;
            _appContext.MainForm = newForm;
            oldForm?.Close();
            newForm.Show();
        }
    }
}