using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class GoogleHomePage : WebPage
    {
        public new string sWindowTitle = "Google";
        public EnhancedHtmlEdit txtSearch = new EnhancedHtmlEdit("Id=lst-ib");
    }
}