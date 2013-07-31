using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class TestHtmlPage : WebPage
    {
        public EnhancedHtmlUnorderedList list = new EnhancedHtmlUnorderedList("id=unorderedList");
        public EnhancedHtmlParagraph p = new EnhancedHtmlParagraph("id=para1");
        public EnhancedHtmlListItem displayNone = new EnhancedHtmlListItem("id=displayNone");
        public EnhancedHtmlListItem hidden = new EnhancedHtmlListItem("id=visiblityHidden");
        public new string sWindowTitle = "A Test";
    }
}