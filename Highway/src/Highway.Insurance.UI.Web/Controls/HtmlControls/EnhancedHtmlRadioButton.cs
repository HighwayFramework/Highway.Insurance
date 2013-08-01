using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlRadioButton : EnhancedHtmlControl<HtmlRadioButton>
    {
        public EnhancedHtmlRadioButton() : base() { }
        public EnhancedHtmlRadioButton(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlRadioButton(WebPage page, string selector) : base(page, selector) { }

        public void Select()
        {
            this.Control.WaitForControlReady();
            this.Control.Selected = true;
        }

        public void Select2()
        {
            this.Control.WaitForControlReady();
            string sOnClick = (string)this.Control.GetProperty("onclick");
            string sId = this.Control.Id;
            if (sId == null || sId == "")
            {
                throw new HighwayInsuranceGenericException("Select2(): No ID found for the RadioButton!");
            }
            ((BrowserWindow)Control.TopParent).ExecuteScript("document.getElementById('" + sId + "').checked=true;" + sOnClick);
        }

        public bool IsSelected
        {
            get {
                this.Control.WaitForControlReady();
                return this.Control.Selected; 
            }
        }
    }
}
