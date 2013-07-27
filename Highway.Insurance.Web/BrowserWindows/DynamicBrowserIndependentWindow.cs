using System;
using Highway.Insurance.UI.Web.Controls.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Highway.Insurance.UI.Web.BrowserWindows
{
    public class DynamicBrowserIndependentWindow : DynamicWebPage
    {
        public DynamicBrowserIndependentWindow(string title)
            : base(title)
        {
            if (BrowserWindow.CurrentBrowser.Equals(BroswerConstants.Chrome, StringComparison.InvariantCultureIgnoreCase))
            {
                SearchProperties.Clear();
                SearchProperties[UITestControl.PropertyNames.ClassName] = BroswerWindowClassesConstants.Chrome;
                SearchProperties[UITestControl.PropertyNames.Name] = sWindowTitle;
            }
            else if (BrowserWindow.CurrentBrowser.Equals(BroswerConstants.FireFox, StringComparison.InvariantCultureIgnoreCase))
            {
                SearchProperties.Clear();
                SearchProperties[UITestControl.PropertyNames.ClassName] = BroswerWindowClassesConstants.FireFox;
                SearchProperties[UITestControl.PropertyNames.Name] = sWindowTitle;
            }
        }
    }
}