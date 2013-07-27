using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinCalendar
    /// </summary>
    public class EnhancedWinCalendar : EnhancedWinControl<WinCalendar>
    {
        public EnhancedWinCalendar() : base() { }
        public EnhancedWinCalendar(string searchParameters) : base(searchParameters) { }

        public SelectionRange SelectionRange
        {
            get { return this.UnWrap().SelectionRange; }
            set { this.UnWrap().SelectionRange = value; }
        }

        public string SelectionRangeAsString
        {
            get { return this.UnWrap().SelectionRangeAsString; }
            set { this.UnWrap().SelectionRangeAsString = value; }
        }
    }
}