using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinHyperLink
    /// </summary>
    public class EnhancedWinHyperlink : EnhancedWinControl<WinHyperlink>
    {
        public EnhancedWinHyperlink() : base() { }
        public EnhancedWinHyperlink(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }
    }
}