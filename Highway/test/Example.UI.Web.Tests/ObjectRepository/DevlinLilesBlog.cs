using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class DevlinLilesBlog : WebPage
    {
        public EnhancedHtmlHyperlink SecondBlogTitle
        {
            get { return new EnhancedHtmlHyperlink(this, "div#post1  h2  a"); }
        }
    }
}