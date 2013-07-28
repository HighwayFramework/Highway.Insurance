using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlDocument : EnhancedHtmlControl<HtmlDocument>
    {
        public EnhancedHtmlDocument() : base() { }
        public EnhancedHtmlDocument(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlDocument(HtmlDocument control) : base(control) { }
    }
}
