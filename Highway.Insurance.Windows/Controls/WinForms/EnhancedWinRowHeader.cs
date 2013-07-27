using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinRowHeader
    /// </summary>
    public class EnhancedWinRowHeader : EnhancedWinControl<WinRowHeader>
    {
        public EnhancedWinRowHeader() : base() { }
        public EnhancedWinRowHeader(string searchParameters) : base(searchParameters) { }

        public bool Selected
        {
            get { return this.UnWrap().Selected; }
        }
    }
}