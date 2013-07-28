namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlUnorderedList : EnhancedHtmlCustom
    {
        private const string _tagName = "ul";
        public EnhancedHtmlUnorderedList(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlUnorderedList(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
