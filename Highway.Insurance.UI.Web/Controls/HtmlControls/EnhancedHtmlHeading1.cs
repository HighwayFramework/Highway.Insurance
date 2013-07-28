namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlHeading1 : EnhancedHtmlCustom
    {
        private const string _tagName = "h1";

        public EnhancedHtmlHeading1(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlHeading1(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
