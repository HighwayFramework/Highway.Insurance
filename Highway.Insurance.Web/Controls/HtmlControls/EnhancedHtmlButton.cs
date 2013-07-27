using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlButton : EnhancedHtmlControl<HtmlButton>
    {
        public EnhancedHtmlButton() : base() { }
        public EnhancedHtmlButton(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlButton(HtmlButton control) : base(control) { }
    }
}
