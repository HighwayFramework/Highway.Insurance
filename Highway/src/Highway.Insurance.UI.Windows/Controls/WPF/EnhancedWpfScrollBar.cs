using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfScrollBar
    /// </summary>
    public class EnhancedWpfScrollBar : EnhancedWpfControl<WpfScrollBar>
    {
        public EnhancedWpfScrollBar() : base() { }
        public EnhancedWpfScrollBar(string searchParameters) : base(searchParameters) { }

        public double MaximumPosition
        {
            get { return this.UnWrap().MaximumPosition; }
        }

        public double MinimumPosition
        {
            get { return this.UnWrap().MinimumPosition; }
        }

        public double Position
        {
            get { return this.UnWrap().Position; }
        }
    }
}