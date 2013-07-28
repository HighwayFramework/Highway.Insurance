using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class Div2 : EnhancedHtmlDiv
    {
        public Div2()
            : base("id=div2")
        {
        }

        public EnhancedHtmlEdit edit
        {
            get { return this.Get<EnhancedHtmlEdit>("id=edit"); }
        }
    }
}