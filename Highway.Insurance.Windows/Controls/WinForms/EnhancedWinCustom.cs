using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinCustom
    /// </summary>
    public class EnhancedWinCustom : EnhancedWinControl<WinCustom>
    {
        public EnhancedWinCustom() : base() { }
        public EnhancedWinCustom(string searchParameters) : base(searchParameters) { }
    }
}