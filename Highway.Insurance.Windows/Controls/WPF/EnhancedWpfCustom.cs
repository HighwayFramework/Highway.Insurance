using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfCustom
    /// </summary>
    public class EnhancedWpfCustom : EnhancedWpfControl<WpfCustom>
    {
        public EnhancedWpfCustom() : base() { }
        public EnhancedWpfCustom(string searchParameters) : base(searchParameters) { }
    }
}