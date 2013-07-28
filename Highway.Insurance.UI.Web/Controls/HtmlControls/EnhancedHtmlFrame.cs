using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlFrame : EnhancedHtmlControl<HtmlFrame>
    {
        public EnhancedHtmlFrame() : base() { }
        public EnhancedHtmlFrame(string sSearchProperties) : base(sSearchProperties) { }
        public EnhancedHtmlFrame(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlFrame(HtmlFrame control) : base(control) { }
    }
}