using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinCell
    /// </summary>
    public class EnhancedWinCell : EnhancedWinControl<WinCell>
    {
        public EnhancedWinCell() : base() { }
        public EnhancedWinCell(string searchParameters) : base(searchParameters) { }

        public bool Checked
        {
            get { return this.UnWrap().Checked; }
            set { this.UnWrap().Checked = value; }
        }
        
        public int ColumnIndex
        {
            get { return this.UnWrap().ColumnIndex; }
        }

        public bool Indeterminate
        {
            get { return this.UnWrap().Indeterminate; }
            set { this.UnWrap().Indeterminate = value; }
        }

        public int RowIndex
        {
            get { return this.UnWrap().RowIndex; }
        }

        public bool Selected
        {
            get { return this.UnWrap().Selected; }
        }

        public string Value
        {
            get { return this.UnWrap().Value; }
            set { this.UnWrap().Value = value; }
        }

    }
}