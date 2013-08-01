using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlInputButton : EnhancedHtmlControl<HtmlInputButton>
    {
        public EnhancedHtmlInputButton() : base() { }
        public EnhancedHtmlInputButton(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlInputButton(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlInputButton(HtmlInputButton control) : base(control) { }

        public string DisplayText
        {
            get
            {
                return this.Control.DisplayText;
            }
        }
    }
}
