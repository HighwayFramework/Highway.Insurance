namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlOrderedList : EnhancedHtmlCustom
    {
        private const string _tagName = "ol";
        public EnhancedHtmlOrderedList(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlOrderedList(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
