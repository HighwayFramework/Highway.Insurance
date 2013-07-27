using System.Threading;
using Highway.Insurance.UI.Web.Controls.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.TelerikControls
{
    public class TelerikComboBox : EnhancedHtmlControl<HtmlDiv>
    {
        private string id;
        private WebPage _window;
        
        public TelerikComboBox() : base() { }

        public TelerikComboBox(string searchParameters)
            : base(searchParameters)
        {
            this.id = searchParameters.Trim().Split('=', '~')[1];
        }

        internal void SetWindow(WebPage window) 
        {
            this._window = window;
        }

        public void SelectItemByText(string sText, int milliseconds)
        {
            this._window.ExecuteScript("var obj = window.$find('" + id + "');obj.toggleDropDown();");
            Thread.Sleep(milliseconds);
            this._window.ExecuteScript("var obj = window.$find('" + id + "');obj.findItemByText('" + sText + "').select();obj.hideDropDown();");
        }
    }
}
