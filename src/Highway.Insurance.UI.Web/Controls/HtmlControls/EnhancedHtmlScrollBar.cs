using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlScrollBar : EnhancedHtmlControl<HtmlScrollBar>
    {
        public EnhancedHtmlScrollBar() : base() { }
        public EnhancedHtmlScrollBar(string sSearchProperties) : base(sSearchProperties) { }
        public EnhancedHtmlScrollBar(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlScrollBar(HtmlScrollBar control) : base(control) { }
    }
}