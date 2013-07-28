using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class GoogleHomePageWithInvalidControlSearchProperties : WebPage
    {
        public EnhancedHtmlDiv controlWithInvalidSearchProperties = new EnhancedHtmlDiv("blanblah=res");
        public new string sWindowTitle = "Google";
    }
}