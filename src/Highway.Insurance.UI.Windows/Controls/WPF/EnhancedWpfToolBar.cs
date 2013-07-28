using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfToolBar
    /// </summary>
    public class EnhancedWpfToolBar : EnhancedWpfControl<WpfToolBar>
    {
        public EnhancedWpfToolBar() : base() { }
        public EnhancedWpfToolBar(string searchParameters) : base(searchParameters) { }

        public string Header
        {
            get { return this.UnWrap().Header; }
        }

        public UITestControlCollection Items
        {
            get { return this.UnWrap().Items; }
        }
    }
}