using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlSlider : EnhancedHtmlControl<HtmlSlider>
    {
        public EnhancedHtmlSlider() : base() { }
        public EnhancedHtmlSlider(string sSearchProperties) : base(sSearchProperties) { }
        public EnhancedHtmlSlider(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlSlider(HtmlSlider control) : base(control) { }
    }
}