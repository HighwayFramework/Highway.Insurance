using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlRow : EnhancedHtmlControl<HtmlRow>
    {
        public EnhancedHtmlRow() : base() { }
        public EnhancedHtmlRow(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlRow(HtmlControl control) : base(control) { }
    }
}
