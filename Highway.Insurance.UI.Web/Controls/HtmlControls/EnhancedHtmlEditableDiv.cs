using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlEditableDiv : EnhancedHtmlControl<HtmlEditableDiv>
    {
        public EnhancedHtmlEditableDiv() : base() { }
        public EnhancedHtmlEditableDiv(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlEditableDiv(HtmlEditableDiv control) : base(control) { }

        public void SetText(string sText)
        {
            this._control.WaitForControlReady();
            this._control.Text = sText;
        }

        public string GetText()
        {
            this._control.WaitForControlReady();
            return this._control.Text; 
        }

        public bool ReadOnly
        {
            get
            {
                this._control.WaitForControlReady();
                return this._control.ReadOnly;
            }
        }
    }
}
