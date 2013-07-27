using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlCheckBox : EnhancedHtmlControl<HtmlCheckBox>
    {
        public EnhancedHtmlCheckBox() : base() { }        
        public EnhancedHtmlCheckBox(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlCheckBox(HtmlCheckBox control) : base(control) { }

        public void Check()
        {
            this._control.WaitForControlReady();
            if (!this._control.Checked)
            {
                this._control.Checked = true;
            }
        }

        public void Check2()
        {
            this._control.WaitForControlReady();
            string sOnClick = (string)this._control.GetProperty("onclick");
            string sId = this._control.Id;
            if (sId == null || sId == "")
            {
                throw new HighwayInsuranceGenericException("Check2(): No ID found for the checkbox!");
            }
            ((BrowserWindow)_control.TopParent).ExecuteScript("document.getElementById('" + sId + "').checked=true;" + sOnClick);
        }

        public void UnCheck()
        {
            this._control.WaitForControlReady();
            if (this._control.Checked)
            {
                this._control.Checked = false;
            }
        }

        public bool Checked
        {
            get 
            {
                this._control.WaitForControlReady();
                return this._control.Checked; 
            }
        }
    }
}
