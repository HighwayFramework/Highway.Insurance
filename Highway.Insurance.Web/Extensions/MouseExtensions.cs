using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Extensions
{
    public static class MouseExtensions
    { 
        public static void Click(this HtmlControl control)
        {
            Mouse.Click(control);
        }
    }
}
