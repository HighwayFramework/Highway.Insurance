using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinText
    /// </summary>
    public class EnhancedWinText : EnhancedWinControl<WinText>
    {
        public EnhancedWinText() : base() { }
        public EnhancedWinText(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }
    }
}
