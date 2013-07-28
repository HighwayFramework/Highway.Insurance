using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinPane
    /// </summary>
    public class EnhancedWinPane : EnhancedWinControl<WinPane>
    {
        public EnhancedWinPane() : base() { }
        public EnhancedWinPane(string searchParameters) : base(searchParameters) { }
    }
}