using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Example.UI.Web.Tests.ObjectRepository
{
    public class HtmlTestPageFeeds : WebPage
    {
        public HtmlTestPageFeeds()
            : base("test")
        {
        }

        public EnhancedHtmlCustom cusDataFeedTabsNav2
        {
            get { return divFeedTabs.Get<EnhancedHtmlCustom>("Class=dataFeedTab ui-tabs-nav"); }
        }

        public EnhancedHtmlUnorderedList cusDataFeedTabsNav
        {
            get { return this.Get<EnhancedHtmlUnorderedList>("Class=dataFeedTab ui-tabs-nav;TagName=ul"); }
        }

        public EnhancedHtmlDiv divFeedTabs
        {
            get { return this.Get<EnhancedHtmlDiv>("Id=feed_tabs"); }
        }

        public EnhancedHtmlUnorderedList cusdatafeedtabsnav1
        {
            get { return (divFeedTabs.Get<EnhancedHtmlUnorderedList>("Class=dataFeedTab ui-tabs-nav;TagName=ul")); }
        }

        public EnhancedHtmlCustom cusDataFeedTabsNav3
        {
            get { return divFeedTabs.Get<EnhancedHtmlCustom>("Class=dataFeedTab ui-tabs-nav;TagName=ul"); }
        }
    }
}