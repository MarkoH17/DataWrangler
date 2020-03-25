using System;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace DataWrangler
{
    internal class StyleHelper
    {
        private static readonly MetroStyleManager AppStyleManager = new MetroStyleManager();

        private static void InvokeSwitchStyle(MetroForm form)
        {
            var switchFormStyleMethod = form.GetType().GetMethod("SwitchFormStyle");
            if (switchFormStyleMethod != null) switchFormStyleMethod.Invoke(form, null);
        }

        public static void LoadFormSavedStyle(MetroForm form)
        {
            var themeStyle = MetroThemeStyle.Default;
            var colorStyle = MetroColorStyle.Orange;

            var savedStyle = ConfigurationHelper.GetStyleSettings();

            if (savedStyle.ContainsKey("ThemeStyle"))
                themeStyle = (MetroThemeStyle) Enum.Parse(typeof(MetroThemeStyle), savedStyle["ThemeStyle"]);

            if (savedStyle.ContainsKey("ColorStyle"))
                colorStyle = (MetroColorStyle) Enum.Parse(typeof(MetroColorStyle), savedStyle["ColorStyle"]);

            SetThemeStyle(themeStyle);
            SetColorStyle(colorStyle);
            UpdateFormStyle(form);
        }

        public static void PreviewFormStyle(MetroForm form, MetroThemeStyle themeStyle, MetroColorStyle colorStyle)
        {
            form.StyleManager = AppStyleManager;
            AppStyleManager.Owner = form;
            SetThemeStyle(themeStyle);
            SetColorStyle(colorStyle);
            InvokeSwitchStyle(form);
        }

        private static void SetColorStyle(MetroColorStyle colorStyle)
        {
            AppStyleManager.Style = colorStyle;
        }

        private static void SetThemeStyle(MetroThemeStyle themeStyle)
        {
            AppStyleManager.Theme = themeStyle;
        }

        private static void UpdateFormStyle(MetroForm form)
        {
            form.StyleManager = AppStyleManager;
            AppStyleManager.Owner = form;

            InvokeSwitchStyle(form);
        }
    }
}