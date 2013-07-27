using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlRadioButton : EnhancedHtmlControl<HtmlRadioButton>
    {
        public EnhancedHtmlRadioButton() : base() { }
        public EnhancedHtmlRadioButton(string searchParameters) : base(searchParameters) { }

        public void Select()
        {
            this._control.WaitForControlReady();
            this._control.Selected = true;
        }

        public void Select2()
        {
            this._control.WaitForControlReady();
            string sOnClick = (string)this._control.GetProperty("onclick");
            string sId = this._control.Id;
            if (sId == null || sId == "")
            {
                throw new HighwayInsuranceGenericException("Select2(): No ID found for the RadioButton!");
            }
            ((BrowserWindow)_control.TopParent).ExecuteScript("document.getElementById('" + sId + "').checked=true;" + sOnClick);
        }

        public bool IsSelected
        {
            get {
                this._control.WaitForControlReady();
                return this._control.Selected; 
            }
        }
    }
}
