using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinListItem
    /// </summary>
    public class EnhancedWinListItem : EnhancedWinControl<WinListItem>
    {
        public EnhancedWinListItem() : base() { }
        public EnhancedWinListItem(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }

        public bool Selected
        {
            get { return this.UnWrap().Selected; }
        }
    }
}