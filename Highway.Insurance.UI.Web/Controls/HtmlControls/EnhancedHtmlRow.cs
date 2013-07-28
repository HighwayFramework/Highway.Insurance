using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlRow : EnhancedHtmlControl<HtmlRow>
    {
        public EnhancedHtmlRow() : base() { }
        public EnhancedHtmlRow(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlRow(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlRow(HtmlControl control) : base(control) { }
    }
}
