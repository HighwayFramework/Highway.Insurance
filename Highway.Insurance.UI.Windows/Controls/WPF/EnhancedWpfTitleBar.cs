using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfTitleBar
    /// </summary>
    public class EnhancedWpfTitleBar : EnhancedWpfControl<WpfTitleBar>
    {
        public EnhancedWpfTitleBar() : base() { }
        public EnhancedWpfTitleBar(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }
    }
}