using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinColumnHeader
    /// </summary>
    public class EnhancedWinColumnHeader : EnhancedWinControl<WinColumnHeader>
    {
        public EnhancedWinColumnHeader() : base() { }
        public EnhancedWinColumnHeader(string searchParameters) : base(searchParameters) { }
    }
}