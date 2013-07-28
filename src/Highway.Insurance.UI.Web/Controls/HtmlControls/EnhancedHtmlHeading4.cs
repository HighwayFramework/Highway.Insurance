namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlHeading4 : EnhancedHtmlCustom
    {
        private const string _tagName = "h4";

        public EnhancedHtmlHeading4(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlHeading4(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
