using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlSpan : EnhancedHtmlControl<HtmlSpan>
    {
        public EnhancedHtmlSpan() : base() { }
        public EnhancedHtmlSpan(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlSpan(WebPage page, string selector) : base(page, selector) { }
    }
}
