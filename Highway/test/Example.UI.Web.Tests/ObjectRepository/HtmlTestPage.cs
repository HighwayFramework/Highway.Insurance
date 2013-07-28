using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class HtmlTestPage : WebPage
    {
        public HtmlTestPage()
            : base("test")
        {
        }

        public Div1 div1
        {
            get { return this.Get<Div1>(); }
        }
    }
}