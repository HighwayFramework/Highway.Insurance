using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinGroup
    /// </summary>
    public class EnhancedWinGroup : EnhancedWinControl<WinGroup>
    {
        public EnhancedWinGroup() : base() { }
        public EnhancedWinGroup(string searchParameters) : base(searchParameters) { }
    }
}