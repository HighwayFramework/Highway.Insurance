using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfProgressBar
    /// </summary>
    public class EnhancedWpfProgressBar : EnhancedWpfControl<WpfProgressBar>
    {
        public EnhancedWpfProgressBar() : base() { }
        public EnhancedWpfProgressBar(string searchParameters) : base(searchParameters) { }

        public double MaximumValue
        {
            get { return this.UnWrap().MaximumValue; }
        }

        public double MinimumValue
        {
            get { return this.UnWrap().MinimumValue; }
        }

        public double Position
        {
            get { return this.UnWrap().Position; }
        }
    }
}