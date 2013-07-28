using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinTable
    /// </summary>
    public class EnhancedWinTable : EnhancedWinControl<WinTable>
    {
        public EnhancedWinTable() : base() { }
        public EnhancedWinTable(string searchParameters) : base(searchParameters) { }

        public UITestControlCollection Cells
        {
            get { return this.UnWrap().Cells; }
        }

        public List<EnhancedWinCell> CellsAsEnhanced
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

        public UITestControlCollection ColumnHeaders
        {
            get { return this.UnWrap().ColumnHeaders; }
        }

        public UITestControl HorizontalScrollBar
        {
            get { return this.UnWrap().HorizontalScrollBar; }
        }

        public UITestControlCollection RowHeaders
        {
            get { return this.UnWrap().RowHeaders; }
        }

        public UITestControlCollection Rows
        {
            get { return this.UnWrap().Rows; }
        }

        public List<EnhancedWinRow> RowsAsEnhanced
        {
            get
            {
                List<EnhancedWinRow> list = new List<EnhancedWinRow>();
                foreach (WinRow control in this.UnWrap().Rows)
                {
                    EnhancedWinRow row = new EnhancedWinRow();
                    row.WrapReady(control);
                    list.Add(row);
                }
                return list;
            }
        }

        public UITestControl VerticalScrollBar
        {
            get { return this.UnWrap().VerticalScrollBar; }
        }
    }
}