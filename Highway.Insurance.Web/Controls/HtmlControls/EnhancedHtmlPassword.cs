using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlPassword : EnhancedHtmlEdit
    {
        public EnhancedHtmlPassword() : base() { }
        public EnhancedHtmlPassword(string searchParameters) : base(searchParameters) { }

        public override void Wrap(object control)
        {
            base.Wrap(control);
            this._control = control as HtmlEdit;
            this._control.FilterProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
        }
    }
}
