using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlDiv : EnhancedHtmlControl<HtmlDiv>
    {
        public EnhancedHtmlDiv() : base() { }
        public EnhancedHtmlDiv(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlDiv(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlDiv(HtmlDiv control) : base(control) { }
    }
}
