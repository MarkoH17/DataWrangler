using System.Collections.Generic;
using System.Configuration;
using System.Reflection;

namespace DataWrangler
{
    internal class ConfigurationHelper
    {
        public bool SaveDbSettings(string dbFilePath, bool isEncrypted = false, string dbPass = null)
        {
            if (string.IsNullOrEmpty(dbFilePath)) return false;

            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            if (configuration.AppSettings.Settings["dbFilePath"] != null)
                configuration.AppSettings.Settings["dbFilePath"].Value = dbFilePath;
            else
                configuration.AppSettings.Settings.Add("dbFilePath", dbFilePath);

            if (isEncrypted && !string.IsNullOrEmpty(dbPass))
            {
                if (configuration.AppSettings.Settings["dbPass"] != null)
                    configuration.AppSettings.Settings["dbPass"].Value = dbPass;
                else
                    configuration.AppSettings.Settings.Add("dbPass", dbPass);
            }

            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
            return true;
        }


        public Dictionary<string, string> GetDbSettings()
        {
            var settings = new Dictionary<string, string>();

            var keys = new[] {"dbFilePath", "dbPass"};
            foreach (var key in keys)
            {
                var keyValue = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(keyValue)) settings.Add(key, keyValue);
            }

            return settings;
        }
    }
}