using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfStatusBar
    /// </summary>
    public class EnhancedWpfStatusBar : EnhancedWpfControl<WpfStatusBar>
    {
        public EnhancedWpfStatusBar() : base() { }
        public EnhancedWpfStatusBar(string searchParameters) : base(searchParameters) { }

        public UITestControlCollection Panels
        {
            get { return this.UnWrap().Panels; }
        }
    }
}