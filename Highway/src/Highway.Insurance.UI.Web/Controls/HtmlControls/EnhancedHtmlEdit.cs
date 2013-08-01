using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlEdit : EnhancedHtmlControl<HtmlEdit>
    {
        public EnhancedHtmlEdit() : base() { }
        public EnhancedHtmlEdit(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlEdit(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlEdit(HtmlEdit control) : base(control) { }

        public void SetText(string sText)
        {
            this.Control.WaitForControlReady();
            this.Control.Text = sText;
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
