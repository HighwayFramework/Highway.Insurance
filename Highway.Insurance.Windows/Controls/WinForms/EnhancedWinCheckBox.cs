using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinCheckBox
    /// </summary>
    public class EnhancedWinCheckBox : EnhancedWinControl<WinCheckBox>
    {
        public EnhancedWinCheckBox() : base() { }
        public EnhancedWinCheckBox(string searchParameters) : base(searchParameters) { }

        public bool Checked { 
            get { return this._control.Checked; } 
            set { this._control.Checked = value; }
        }

        public bool Indeterminate
        {
            get { return this._control.Indeterminate; }
            set { this._control.Indeterminate = value; }
        }

    }
}
