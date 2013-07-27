using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlTextArea : EnhancedHtmlControl<HtmlTextArea>
    {
        public EnhancedHtmlTextArea() : base() { }
        public EnhancedHtmlTextArea(string searchParameters) : base(searchParameters) { }

        public void SetText(string sText)
        {
            this._control.WaitForControlReady();
            this._control.Text = sText;
        }

        public string Text
        {
            get 
            {
                this._control.WaitForControlReady();
                return this._control.Text; 
            }
        }

        public bool ReadOnly
        {
            get
            {
                this._control.WaitForControlReady();
                return this._control.ReadOnly;
            }
        }
    }
}
