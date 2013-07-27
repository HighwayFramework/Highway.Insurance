using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlHeaderCell : EnhancedHtmlControl<HtmlHeaderCell>
    {
        public EnhancedHtmlHeaderCell() : base() { }
        public EnhancedHtmlHeaderCell(string sSearchProperties) : base(sSearchProperties) { }
        public EnhancedHtmlHeaderCell(HtmlControl control) : base(control) { }
    }
}
