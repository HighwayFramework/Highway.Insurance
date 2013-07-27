using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfRadioButton
    /// </summary>
    public class EnhancedWpfRadioButton : EnhancedWpfControl<WpfRadioButton>
    {
        public EnhancedWpfRadioButton() : base() { }
        public EnhancedWpfRadioButton(string searchParameters) : base(searchParameters) { }

        public UITestControl Group
        {
            get { return this.UnWrap().Group; }
        }

        public EnhancedWpfGroup GroupAsEnhanced
        {
            get
            {
                EnhancedWpfGroup group = new EnhancedWpfGroup();
                group.WrapReady(this.UnWrap().Group);
                return group;
            }
        }

        public bool Selected
        {
            get { return this.UnWrap().Selected; }
            set { this.UnWrap().Selected = value; }
        }
    }
}