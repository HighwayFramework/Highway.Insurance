using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinTabPage
    /// </summary>
    public class EnhancedWinTabPage : EnhancedWinControl<WinTabPage>
    {
        public EnhancedWinTabPage() : base() { }
        public EnhancedWinTabPage(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }
    }
}