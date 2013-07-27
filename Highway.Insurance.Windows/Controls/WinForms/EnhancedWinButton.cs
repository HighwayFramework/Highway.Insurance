using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinButton
    /// </summary>
    public class EnhancedWinButton : EnhancedWinControl<WinButton>
    {
        public EnhancedWinButton() : base() { }
        public EnhancedWinButton(string searchParameters) : base(searchParameters) { }

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