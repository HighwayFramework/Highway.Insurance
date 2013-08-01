using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlCheckBox : EnhancedHtmlControl<HtmlCheckBox>
    {
        public EnhancedHtmlCheckBox() : base() { }        
        public EnhancedHtmlCheckBox(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlCheckBox(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlCheckBox(HtmlCheckBox control) : base(control) { }

        public void Check()
        {
            this.Control.WaitForControlReady();
            if (!this.Control.Checked)
            {
                this.Control.Checked = true;
            }
        }

        public void Check2()
        {
            this.Control.WaitForControlReady();
            string sOnClick = (string)this.Control.GetProperty("onclick");
            string sId = this.Control.Id;
            if (sId == null || sId == "")
            {
                throw new HighwayInsuranceGenericException("Check2(): No ID found for the checkbox!");
            }
            ((BrowserWindow)Control.TopParent).ExecuteScript("document.getElementById('" + sId + "').checked=true;" + sOnClick);
        }

        public void UnCheck()
        {
            this.Control.WaitForControlReady();
            if (this.Control.Checked)
            {
                this.Control.Checked = false;
            }
        }

        public bool Checked
        {
            get 
            {
                this.Control.WaitForControlReady();
                return this.Control.Checked; 
            }
        }
    }
}
