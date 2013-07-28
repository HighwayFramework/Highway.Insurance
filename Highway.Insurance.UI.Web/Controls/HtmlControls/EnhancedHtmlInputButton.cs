using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlInputButton : EnhancedHtmlControl<HtmlInputButton>
    {
        public EnhancedHtmlInputButton() : base() { }
        public EnhancedHtmlInputButton(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlInputButton(HtmlInputButton control) : base(control) { }

        public string DisplayText
        {
            get
            {
                return this._control.DisplayText;
            }
        }
    }
}
