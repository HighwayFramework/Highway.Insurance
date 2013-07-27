using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfToggleButton
    /// </summary>
    public class EnhancedWpfToggleButton : EnhancedWpfControl<WpfToggleButton>
    {
        public EnhancedWpfToggleButton() : base() { }
        public EnhancedWpfToggleButton(string searchParameters) : base(searchParameters) { }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }

        public bool Indeterminate
        {
            get { return this.UnWrap().Indeterminate; }
            set { this.UnWrap().Indeterminate = value; }
        }

        public bool Pressed
        {
            get { return this.UnWrap().Pressed; }
            set { this.UnWrap().Pressed = value; }
        }
        
    }
}