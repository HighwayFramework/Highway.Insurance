using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfListItem
    /// </summary>
    public class EnhancedWpfListItem : EnhancedWpfControl<WpfListItem>
    {
        public EnhancedWpfListItem() : base() { }
        public EnhancedWpfListItem(string searchParameters) : base(searchParameters) { }

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