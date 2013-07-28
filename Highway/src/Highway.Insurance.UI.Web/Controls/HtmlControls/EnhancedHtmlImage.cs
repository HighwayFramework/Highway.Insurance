using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlImage : EnhancedHtmlControl<HtmlImage>
    {
        public EnhancedHtmlImage() : base() { }
        public EnhancedHtmlImage(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlImage(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlImage(HtmlImage control) : base(control) { }
    }
}
