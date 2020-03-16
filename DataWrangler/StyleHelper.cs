using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace DataWrangler
{
    class StyleHelper
    {
        private static MetroStyleManager _appStyleManager = new MetroStyleManager();
        private static void SetColorStyle(MetroColorStyle colorStyle)
        {
            _appStyleManager.Style = colorStyle;
        }

        private static void SetThemeStyle(MetroThemeStyle themeStyle)
        {
            _appStyleManager.Theme = themeStyle;
        }

        private static void UpdateFormStyle(MetroForm form)
        {
            form.StyleManager = _appStyleManager;
            _appStyleManager.Owner = form;

            var switchIconStyleMethod = form.GetType().GetMethod("SwitchIconStyle");
            if (switchIconStyleMethod != null)
            {
                switchIconStyleMethod.Invoke(form, null);
            }
        }

        public static void PreviewFormStyle(MetroForm form, MetroThemeStyle themeStyle, MetroColorStyle colorStyle)
        {
            form.StyleManager = _appStyleManager;
            _appStyleManager.Owner = form;
            SetThemeStyle(themeStyle);
            SetColorStyle(colorStyle);
        }

        public static void LoadFormSavedStyle(MetroForm form)
        {
            var themeStyle = MetroThemeStyle.Default;
            var colorStyle = MetroColorStyle.Orange;

            var savedStyle = ConfigurationHelper.GetStyleSettings();

            if (savedStyle.ContainsKey("ThemeStyle"))
                themeStyle = (MetroThemeStyle)Enum.Parse(typeof(MetroThemeStyle), savedStyle["ThemeStyle"]);

            if (savedStyle.ContainsKey("ColorStyle"))
                colorStyle = (MetroColorStyle)Enum.Parse(typeof(MetroColorStyle), savedStyle["ColorStyle"]);

            SetThemeStyle(themeStyle);
            SetColorStyle(colorStyle);
            UpdateFormStyle(form);
        }
    }
}
