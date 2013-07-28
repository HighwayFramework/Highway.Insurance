using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinSpinner
    /// </summary>
    public class EnhancedWinSpinner : EnhancedWinControl<WinSpinner>
    {
        public EnhancedWinSpinner() : base() { }
        public EnhancedWinSpinner(string searchParameters) : base(searchParameters) { }

        public int MaximumValue
        {
            get { return this.UnWrap().MaximumValue; }
        }

        public int MinimumValue
        {
            get { return this.UnWrap().MinimumValue; }
        }
    }
}