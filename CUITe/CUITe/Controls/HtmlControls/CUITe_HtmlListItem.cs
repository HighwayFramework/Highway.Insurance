using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CUITe.Controls.HtmlControls
{
    public class CUITe_HtmlListItem : CUITe_HtmlControl<HtmlListItem>
    {
        private const string _tagName = "li";

        public CUITe_HtmlListItem(string searchParameters = null) : base(searchParameters) { }
        public CUITe_HtmlListItem(HtmlListItem control) : base(control) { }
    }
}
