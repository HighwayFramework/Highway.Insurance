using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlListItem : EnhancedHtmlControl<HtmlListItem>
    {
        private const string _tagName = "li";

        public EnhancedHtmlListItem(string searchParameters = null) : base(searchParameters) { }
        public EnhancedHtmlListItem(HtmlListItem control) : base(control) { }
    }
}
