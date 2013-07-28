using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinStatusBar
    /// </summary>
    public class EnhancedWinStatusBar : EnhancedWinControl<WinStatusBar>
    {
        public EnhancedWinStatusBar() : base() { }
        public EnhancedWinStatusBar(string searchParameters) : base(searchParameters) { }

        public UITestControlCollection Panels
        {
            get { return this.UnWrap().Panels; }
        }
    }
}