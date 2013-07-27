using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinRow
    /// </summary>
    public class EnhancedWinRow : EnhancedWinControl<WinRow>
    {
        public EnhancedWinRow() : base() { }
        public EnhancedWinRow(string searchParameters) : base(searchParameters) { }

        public UITestControlCollection Cells
        {
            get { return this.UnWrap().Cells; }
        }

        public List<EnhancedWinCell> CellsAsCUITe
        {
            get
            {
                List<EnhancedWinCell> list = new List<EnhancedWinCell>();
                foreach (WinCell control in this.UnWrap().Cells)
                {
                    EnhancedWinCell cell = new EnhancedWinCell();
                    cell.WrapReady(control);
                    list.Add(cell);
                }
                return list;
            }
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
        }
    }
}