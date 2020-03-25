using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using DataWrangler.Properties;
using MetroFramework;

namespace DataWrangler
{
    public class ConfigurationHelper
    {
        public static string GetConnectionString(Dictionary<string, string> dbSettings)
        {
            string connectionString;
            connectionString = !dbSettings.ContainsKey("dbPass")
                ? $"Filename={dbSettings["dbFilePath"]};Connection=shared"
                : $"Filename={dbSettings["dbFilePath"]};Password='{dbSettings["dbPass"]}';Connection=shared";

            return connectionString;
        }

        public static Dictionary<string, string> GetDbSettings()
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

        public static Dictionary<string, string> GetLoginSettings()
        {
            var settings = new Dictionary<string, string>();

            var keys = new[] {"Username"};
            foreach (var key in keys)
            {
                var keyValue = Settings.Default[key]?.ToString();
                if (!string.IsNullOrEmpty(keyValue)) settings.Add(key, keyValue);
            }

            return settings;
        }

        public static Dictionary<string, string> GetStyleSettings()
        {
            var settings = new Dictionary<string, string>();

            var keys = new[] {"ThemeStyle", "ColorStyle"};
            foreach (var key in keys)
            {
                var keyValue = Settings.Default[key].ToString();
                if (!string.IsNullOrEmpty(keyValue)) settings.Add(key, keyValue);
            }

            var themeValid = false;
            if (settings.ContainsKey("ThemeStyle"))
            {
                var themeStyleValue = settings["ThemeStyle"];
                foreach (var themeStyle in Enum.GetValues(typeof(MetroThemeStyle)))
                    if (themeStyle.ToString().Equals(themeStyleValue))
                        themeValid = true;
            }

            var colorValid = false;
            if (settings.ContainsKey("ColorStyle"))
            {
                var colorStyleValue = settings["ColorStyle"];
                foreach (var colorStyle in Enum.GetValues(typeof(MetroColorStyle)))
                    if (colorStyle.ToString().Equals(colorStyleValue))
                        colorValid = true;
            }

            if (themeValid && colorValid) return settings;
            return null;
        }

        public static bool ResetAllPreferences()
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            configuration.AppSettings.Settings.Remove("dbFilePath");
            configuration.AppSettings.Settings.Remove("dbPass");
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
            return true;
        }

        public static bool SaveDbSettings(string dbFilePath, bool isEncrypted = false, string dbPass = null)
        {
            if (string.IsNullOrEmpty(dbFilePath)) return false;

            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

            configuration.AppSettings.Settings.Remove("dbFilePath");
            configuration.AppSettings.Settings.Remove("dbPass");

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

        public static bool SaveLoginSettings(string username)
        {
            Settings.Default["Username"] = username;
            Settings.Default.Save();
            return true;
        }

        public static bool SaveStyleSettings(MetroThemeStyle themeStyle, MetroColorStyle colorStyle)
        {
            Settings.Default["ThemeStyle"] = themeStyle;
            Settings.Default["ColorStyle"] = colorStyle;
            Settings.Default.Save();
            return true;
        }
    }
}