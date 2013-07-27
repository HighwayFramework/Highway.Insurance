using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinProgressBar
    /// </summary>
    public class EnhancedWinProgressBar : EnhancedWinControl<WinProgressBar>
    {
        public EnhancedWinProgressBar() : base() { }
        public EnhancedWinProgressBar(string searchParameters) : base(searchParameters) { }

        public double MaximumValue
        {
            get { return this.UnWrap().MaximumValue; }
        }

        public double MinimumValue
        {
            get { return this.UnWrap().MinimumValue; }
        }

        public double Value
        {
            get { return this.UnWrap().Value; }
        }
    }
}