using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinTitleBar
    /// </summary>
    public class EnhancedWinTitleBar : EnhancedWinControl<WinTitleBar>
    {
        public EnhancedWinTitleBar() : base() { }
        public EnhancedWinTitleBar(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }
    }
}