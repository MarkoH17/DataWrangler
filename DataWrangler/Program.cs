using System;
using System.Windows.Forms;

namespace DataWrangler
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login log = new Login();
            log.Show();
            Application.Run();
        }
    }
}