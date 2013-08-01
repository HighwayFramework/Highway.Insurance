using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlEditableSpan : EnhancedHtmlControl<HtmlEditableSpan>
    {
        public EnhancedHtmlEditableSpan() : base() { }
        public EnhancedHtmlEditableSpan(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlEditableSpan(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlEditableSpan(HtmlEditableSpan control) : base(control) { }

        public void SetText(string sText)
        {
            this.Control.WaitForControlReady();
            this.Control.CopyPastedText = sText;
        }

        public string GetText()
        {
            this.Control.WaitForControlReady();
            return this.Control.Text; 
        }

        public bool ReadOnly
        {
            get
            {
                this.Control.WaitForControlReady();
                return this.Control.ReadOnly;
            }
        }
    }
}
