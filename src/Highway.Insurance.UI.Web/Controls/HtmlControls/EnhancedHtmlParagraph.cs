namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlParagraph : EnhancedHtmlCustom
    {
        private const string _tagName = "p";
        public EnhancedHtmlParagraph(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlParagraph(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
