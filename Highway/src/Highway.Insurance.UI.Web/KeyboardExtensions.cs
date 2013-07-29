using Highway.Insurance.UI.Web.Controls.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Highway.Insurance.UI.Web
{
    public static class KeyboardExtensions
    {
        public static void SendEnter(this EnhancedHtmlEdit control)
        {
            Keyboard.SendKeys(control.UnWrap(), "{Enter}");
        }

        public static void SendEnter(this EnhancedHtmlEditableDiv control)
        {
            Keyboard.SendKeys(control.UnWrap(), "{Enter}");
        }

        public static void SendEnter(this EnhancedHtmlEditableSpan control)
        {
            Keyboard.SendKeys(control.UnWrap(),"{Enter}");
        }
    }
}