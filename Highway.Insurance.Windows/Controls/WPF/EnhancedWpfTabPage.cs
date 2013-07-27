using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfTabPage
    /// </summary>
    public class EnhancedWpfTabPage : EnhancedWpfControl<WpfTabPage>
    {
        public EnhancedWpfTabPage() : base() { }
        public EnhancedWpfTabPage(string searchParameters) : base(searchParameters) { }

        public string Header
        {
            get { return this.UnWrap().Header; }
        }
    }
}