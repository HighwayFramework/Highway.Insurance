using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlCell : EnhancedHtmlControl<HtmlCell>
    {
        public EnhancedHtmlCell() : base() { }
        public EnhancedHtmlCell(string sSearchProperties) : base(sSearchProperties) { }
        public EnhancedHtmlCell(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlCell(HtmlControl control) : base(control) { }
    }
}
