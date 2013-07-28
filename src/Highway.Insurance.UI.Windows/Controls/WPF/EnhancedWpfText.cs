using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfText
    /// </summary>
    public class EnhancedWpfText : EnhancedWpfControl<WpfText>
    {
        public EnhancedWpfText() : base() { }
        public EnhancedWpfText(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }
    }
}