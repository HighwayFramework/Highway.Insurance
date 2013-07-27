using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfCheckBox
    /// </summary>
    public class EnhancedWpfCheckBox : EnhancedWpfControl<WpfCheckBox>
    {
        public EnhancedWpfCheckBox() : base() { }
        public EnhancedWpfCheckBox(string searchParameters) : base(searchParameters) { }

        public bool Checked
        {
            get { return this.UnWrap().Checked; }
            set { this.UnWrap().Checked = value; }
        }

        public bool Indeterminate
        {
            get { return this.UnWrap().Indeterminate; }
            set { this.UnWrap().Indeterminate = value; }
        }

    }
}