using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlCustom : EnhancedHtmlControl<HtmlCustom>
    {
        public EnhancedHtmlCustom(string tagName)
            : base()
        {
            Initialize(tagName);
        }

        public EnhancedHtmlCustom(string tagName, string searchParameters)
            : base(searchParameters)
        {
            Initialize(tagName);
        }

        public EnhancedHtmlCustom(HtmlCustom control) : base(control) { }

        private void Initialize(string tagName)
        {
            this.SearchProperties.Add(HtmlControl.PropertyNames.TagName, tagName, PropertyExpressionOperator.EqualTo);
        }
    }
}
