using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinClient
    /// </summary>
    public class EnhancedWinClient : EnhancedWinControl<WinClient>
    {
        public EnhancedWinClient() : base() { }
        public EnhancedWinClient(string searchParameters) : base(searchParameters) { }
    }
}