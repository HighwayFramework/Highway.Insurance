using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlPassword : EnhancedHtmlEdit
    {
        public EnhancedHtmlPassword() : base() { }
        public EnhancedHtmlPassword(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlPassword(WebPage page, string selector) : base(page, selector) { }
        public override void Wrap(object control, bool setSearchProperties = true)
        {
            base.Wrap(control, setSearchProperties);
            this.Control = control as HtmlEdit;
            this.Control.FilterProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
        }
    }
}
