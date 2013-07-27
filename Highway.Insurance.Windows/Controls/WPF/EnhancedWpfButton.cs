using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfButton
    /// </summary>
    public class EnhancedWpfButton : EnhancedWpfControl<WpfButton>
    {
        public EnhancedWpfButton() : base() { }
        public EnhancedWpfButton(string searchParameters) : base(searchParameters) { }

        public string DisplayText { get { return this.UnWrap().DisplayText; } }

    }
}