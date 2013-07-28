using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlHyperlink : EnhancedHtmlControl<HtmlHyperlink>
    {
        public EnhancedHtmlHyperlink() : base() { }
        public EnhancedHtmlHyperlink(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlHyperlink(HtmlHyperlink control) : base(control) { }
    }
}
