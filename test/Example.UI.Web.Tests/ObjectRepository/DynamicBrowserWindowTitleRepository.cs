using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class DynamicBrowserWindowTitleRepository : WebPage
    {
        public EnhancedHtmlButton btnChangeWindowTitle = new EnhancedHtmlButton("id=Change Window Title");
        public EnhancedHtmlButton btnGoToHomePage = new EnhancedHtmlButton("id=Home");
        public EnhancedHtmlButton btnGoToPage1 = new EnhancedHtmlButton("id=1");
        public EnhancedHtmlButton btnGoToPage2 = new EnhancedHtmlButton("id=2");

        public DynamicBrowserWindowTitleRepository(string title)
            : base(title)
        {
        }

        public DynamicBrowserWindowTitleRepository()
            : this("Clicking the buttons changes the window title")
        {
        }
    }
}