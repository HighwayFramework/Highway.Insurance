using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlAudio : EnhancedHtmlControl<HtmlAudio>
    {
        public EnhancedHtmlAudio() : base() { }
        public EnhancedHtmlAudio(string sSearchProperties) : base(sSearchProperties) { }
        public EnhancedHtmlAudio(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlAudio(HtmlAudio control) : base(control) { }
    }
}