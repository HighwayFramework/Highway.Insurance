using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinRadioButton
    /// </summary>
    public class EnhancedWinRadioButton : EnhancedWinControl<WinRadioButton>
    {
        public EnhancedWinRadioButton() : base() { }
        public EnhancedWinRadioButton(string searchParameters) : base(searchParameters) { }

        public UITestControl Group
        {
            get { return this.UnWrap().Group; }
        }

        public EnhancedWinGroup GroupAsEnhanced
        {
            get
            {
                EnhancedWinGroup group = new EnhancedWinGroup();
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