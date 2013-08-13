using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class NoJquery : WebPage
    {
        public new string sWindowTitle = "No Jquery Examples";

        public NoJquery()
        {
            FirstListItem = new EnhancedHtmlListItem(this, "div#list div.container ul li:first");
        }

        public EnhancedHtmlListItem FirstListItem { get; set; }
    }
}