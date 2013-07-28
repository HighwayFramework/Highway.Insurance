using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinSplitButton
    /// </summary>
    public class EnhancedWinSplitButton : EnhancedWinControl<WinSplitButton>
    {
        public EnhancedWinSplitButton() : base() { }
        public EnhancedWinSplitButton(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }

        public string Shortcut
        {
            get { return this.UnWrap().Shortcut; }
        }
    }
}