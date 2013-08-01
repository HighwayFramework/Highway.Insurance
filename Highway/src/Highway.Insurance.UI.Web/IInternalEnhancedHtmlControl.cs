using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Highway.Insurance.UI.Web
{
    internal interface IInternalEnhancedHtmlControl
    {
        string Selector { get; set; }
        WebPage Page { get; set; }
    }
}