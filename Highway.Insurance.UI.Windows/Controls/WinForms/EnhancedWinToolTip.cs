using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinToolTip
    /// </summary>
    public class EnhancedWinToolTip : EnhancedWinControl<WinToolTip>
    {
        public EnhancedWinToolTip() : base() { }
        public EnhancedWinToolTip(string searchParameters) : base(searchParameters) { }
    }
}