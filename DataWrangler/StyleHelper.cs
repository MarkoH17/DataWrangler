using System;
using System.Drawing;
using DataWrangler.Properties;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace DataWrangler
{
    internal class StyleHelper
    {
        private static readonly MetroStyleManager AppStyleManager = new MetroStyleManager();

        private static Icon GetIcon(MetroThemeStyle themeStyle, MetroColorStyle colorStyle)
        {
            Icon icon;
            switch (colorStyle)
            {
                case MetroColorStyle.Blue:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.blue_light : Resources.blue_dark;
                    break;

                case MetroColorStyle.Brown:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.brown_light : Resources.brown_dark;
                    break;

                case MetroColorStyle.Default:
                    icon = Resources.logo_main;
                    break;

                case MetroColorStyle.Green:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.green_light : Resources.green_dark;
                    break;

                case MetroColorStyle.Lime:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.lime_light : Resources.lime_dark;
                    break;

                case MetroColorStyle.Magenta:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.magenta_light : Resources.magenta_dark;
                    break;

                case MetroColorStyle.Orange:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.orange_light : Resources.orange_dark;
                    break;

                case MetroColorStyle.Pink:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.pink_light : Resources.pink_dark;
                    break;

                case MetroColorStyle.Purple:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.purple_light : Resources.purple_dark;
                    break;

                case MetroColorStyle.Red:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.red_light : Resources.red_dark;
                    break;

                case MetroColorStyle.Silver:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.silver_light : Resources.silver_dark;
                    break;

                case MetroColorStyle.Teal:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.teal_light : Resources.teal_dark;
                    break;

                case MetroColorStyle.Yellow:
                    icon = themeStyle == MetroThemeStyle.Light ? Resources.yellow_light : Resources.yellow_dark;
                    break;

                default:
                    icon = Resources.logo_main;
                    break;
            }
            return icon;
        }

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

        private static void UpdateFormIcon(MetroForm form)
        {
            var formThemeStyle = form.Theme;
            var formColorStyle = form.Style;

            var newIcon = GetIcon(formThemeStyle, formColorStyle);
            form.Icon = newIcon;
        }

        private static void UpdateFormStyle(MetroForm form)
        {
            form.StyleManager = AppStyleManager;
            AppStyleManager.Owner = form;
            UpdateFormIcon(form);
            InvokeSwitchStyle(form);
        }
    }
}