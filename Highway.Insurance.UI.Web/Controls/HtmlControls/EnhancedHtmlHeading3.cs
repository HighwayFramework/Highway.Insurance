namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlHeading3 : EnhancedHtmlCustom
    {
        private const string _tagName = "h3";

        public EnhancedHtmlHeading3(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlHeading3(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
