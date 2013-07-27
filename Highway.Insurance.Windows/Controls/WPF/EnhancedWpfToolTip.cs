using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfToolTip
    /// </summary>
    public class EnhancedWpfToolTip : EnhancedWpfControl<WpfToolTip>
    {
        public EnhancedWpfToolTip() : base() { }
        public EnhancedWpfToolTip(string searchParameters) : base(searchParameters) { }
    }
}