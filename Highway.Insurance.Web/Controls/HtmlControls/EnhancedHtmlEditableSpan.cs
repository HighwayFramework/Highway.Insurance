using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlEditableSpan : EnhancedHtmlControl<HtmlEditableSpan>
    {
        public EnhancedHtmlEditableSpan() : base() { }
        public EnhancedHtmlEditableSpan(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlEditableSpan(HtmlEditableSpan control) : base(control) { }

        public void SetText(string sText)
        {
            this._control.WaitForControlReady();
            this._control.CopyPastedText = sText;
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
