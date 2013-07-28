namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlIns : EnhancedHtmlCustom
    {
        private const string _tagName = "ins";
        public EnhancedHtmlIns(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlIns(string searchParameters = null)
            : base(_tagName, searchParameters)
        {
        }
    }
}
