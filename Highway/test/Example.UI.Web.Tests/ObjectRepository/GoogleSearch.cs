using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class GoogleSearch : WebPage
    {
        public EnhancedHtmlDiv divSearchResults = new EnhancedHtmlDiv("Id=ires");
        public new string sWindowTitle = "coded ui test framework - Google Search";
    }
}