using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlLabel : EnhancedHtmlControl<HtmlLabel>
    {
        public EnhancedHtmlLabel() : base() { }
        public EnhancedHtmlLabel(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlLabel(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlLabel(HtmlLabel control) : base(control) { }

        /// <summary>
        /// Gets the name of the control that is associated with this label.
        /// </summary>
        /// <value>
        /// The name of the control that is associated with this label.
        /// </value>
        public string LabelFor
        {
            get
            {
                this.Control.WaitForControlReady();
                return this.Control.LabelFor;
            }
        }
    }
}
