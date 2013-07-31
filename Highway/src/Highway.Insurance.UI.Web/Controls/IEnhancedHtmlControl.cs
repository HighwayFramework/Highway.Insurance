using System.Collections.Generic;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls
{
    public interface IEnhancedHtmlControl : IEnhancedControlBase
    {
        string InnerText
        {
            get;
        }

        string Selector
        {
            get; set;
        }

        WebPage Page
        {
            get; set;
        }

        bool IsVisible();
        Dictionary<string, string> Data();
    }
}