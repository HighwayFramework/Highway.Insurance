using System;
using CUITe.Controls.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Highway.Insurance.CodedUI.Web.BrowserWindows
{
    public class BrowserIndependentWindow : CUITe_BrowserWindow
    {
        public BrowserIndependentWindow()
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