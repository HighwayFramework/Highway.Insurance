using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace CUITe.Controls.HtmlControls
{
    public class CUITe_HtmlInputButton : CUITe_HtmlControl<HtmlInputButton>
    {
        public CUITe_HtmlInputButton() : base() { }
        public CUITe_HtmlInputButton(string searchParameters) : base(searchParameters) { }
        public CUITe_HtmlInputButton(HtmlInputButton control) : base(control) { }

        public string DisplayText
        {
            get
            {
                return this._control.DisplayText;
            }
        }
    }
}
