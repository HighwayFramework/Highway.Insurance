using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfGroup
    /// </summary>
    public class EnhancedWpfGroup : EnhancedWpfControl<WpfGroup>
    {
        public EnhancedWpfGroup() : base() { }
        public EnhancedWpfGroup(string searchParameters) : base(searchParameters) { }

        public string Header
        {
            get { return this.UnWrap().Header; }
        }
    }
}