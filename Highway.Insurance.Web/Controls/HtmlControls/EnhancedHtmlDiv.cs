using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlDiv : EnhancedHtmlControl<HtmlDiv>
    {
        public EnhancedHtmlDiv() : base() { }
        public EnhancedHtmlDiv(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlDiv(HtmlDiv control) : base(control) { }
    }
}
