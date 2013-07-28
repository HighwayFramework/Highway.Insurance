namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlXml : EnhancedHtmlCustom
    {
        private const string _tagName = "xml";
        public EnhancedHtmlXml(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlXml(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
