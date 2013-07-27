using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfPane
    /// </summary>
    public class EnhancedWpfPane : EnhancedWpfControl<WpfPane>
    {
        public EnhancedWpfPane() : base() { }
        public EnhancedWpfPane(string searchParameters) : base(searchParameters) { }
    }
}