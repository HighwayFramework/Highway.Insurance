using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlFileInput : EnhancedHtmlControl<HtmlFileInput>
    {
        public EnhancedHtmlFileInput() : base() { }
        public EnhancedHtmlFileInput(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlFileInput(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlFileInput(HtmlFileInput control) : base(control) { }

        public void SetFile(string sFilePath)
        {
            this.Control.FileName = sFilePath;
        }
    }
}
