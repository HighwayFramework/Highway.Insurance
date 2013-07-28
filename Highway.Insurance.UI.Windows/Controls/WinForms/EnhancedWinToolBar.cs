using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WpfToolBar
    /// </summary>
    public class EnhancedWinToolBar : EnhancedWinControl<WinToolBar>
    {
        public EnhancedWinToolBar() : base() { }
        public EnhancedWinToolBar(string searchParameters) : base(searchParameters) { }

        public UITestControlCollection Items
        {
            get { return this.UnWrap().Items; }
        }
    }
}