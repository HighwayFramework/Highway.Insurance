using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class Div1 : EnhancedHtmlDiv
    {
        public Div1()
            : base("id=div1")
        {
        }

        public Div2 div2
        {
            get { return this.Get<Div2>(); }
        }
    }
}