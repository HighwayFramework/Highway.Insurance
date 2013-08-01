using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlTextArea : EnhancedHtmlControl<HtmlTextArea>
    {
        public EnhancedHtmlTextArea() : base() { }
        public EnhancedHtmlTextArea(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlTextArea(WebPage page, string selector) : base(page, selector) { }
        public void SetText(string sText)
        {
            this.Control.WaitForControlReady();
            this.Control.Text = sText;
        }

        public string Text
        {
            get 
            {
                this.Control.WaitForControlReady();
                return this.Control.Text; 
            }
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
