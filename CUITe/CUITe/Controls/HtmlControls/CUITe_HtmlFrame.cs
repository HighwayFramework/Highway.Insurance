using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CUITe.Controls.HtmlControls
{
    public class CUITe_HtmlFrame : CUITe_HtmlControl<HtmlFrame>
    {
        public CUITe_HtmlFrame() : base() { }
        public CUITe_HtmlFrame(string sSearchProperties) : base(sSearchProperties) { }
        public CUITe_HtmlFrame(HtmlFrame control) : base(control) { }
    }
}