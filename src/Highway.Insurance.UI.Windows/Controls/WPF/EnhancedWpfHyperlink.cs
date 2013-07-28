using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfHyperlink
    /// </summary>
    public class EnhancedWpfHyperlink : EnhancedWpfControl<WpfHyperlink>
    {
        public EnhancedWpfHyperlink() : base() { }
        public EnhancedWpfHyperlink(string searchParameters) : base(searchParameters) { }

        public string Alt
        {
            get { return this.UnWrap().Alt; }
        }
    }
}