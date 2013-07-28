namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlHeading5 : EnhancedHtmlCustom
    {
        private const string _tagName = "h5";
        public EnhancedHtmlHeading5(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlHeading5(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
