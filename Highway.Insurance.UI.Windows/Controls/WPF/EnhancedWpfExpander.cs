using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfExpander
    /// </summary>
    public class EnhancedWpfExpander : EnhancedWpfControl<WpfExpander>
    {
        public EnhancedWpfExpander() : base() { }
        public EnhancedWpfExpander(string searchParameters) : base(searchParameters) { }

        public bool Expanded
        {
            get { return this.UnWrap().Expanded; }
        }

        public string Header
        {
            get { return this.UnWrap().Header; }
        }
    }
}