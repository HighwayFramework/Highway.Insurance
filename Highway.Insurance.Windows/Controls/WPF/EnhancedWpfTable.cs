using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfTable
    /// </summary>
    public class EnhancedWpfTable : EnhancedWpfControl<WpfTable>
    {
        public EnhancedWpfTable() : base() { }
        public EnhancedWpfTable(string searchParameters) : base(searchParameters) { }

        public bool CanSelectMultiple
        {
            get { return this.UnWrap().CanSelectMultiple; }
        }

        public UITestControlCollection Cells
        {
            get { return this.UnWrap().Cells; }
        }

        public List<EnhancedWpfCell> CellsAsCUITe
        {
            get
            {
                List<EnhancedWpfCell> list = new List<EnhancedWpfCell>();
                foreach (WpfCell control in this.UnWrap().Cells)
                {
                    EnhancedWpfCell cell = new EnhancedWpfCell();
                    cell.WrapReady(control);
                    list.Add(cell);
                }
                return list;
            }
        }

        public int ColumnCount
        {
            get { return this.UnWrap().ColumnCount; }
        }

        public UITestControlCollection ColumnHeaders
        {
            get { return this.UnWrap().ColumnHeaders; }
        }

        public int RowCount
        {
            get { return this.UnWrap().RowCount; }
        }

        public UITestControlCollection RowHeaders
        {
            get { return this.UnWrap().RowHeaders; }
        }

        public UITestControlCollection Rows
        {
            get { return this.UnWrap().Rows; }
        }

        public List<EnhancedWpfRow> RowsAsCUITe
        {
            get
            {
                List<EnhancedWpfRow> list = new List<EnhancedWpfRow>();
                foreach (WpfRow control in this.UnWrap().Rows)
                {
                    EnhancedWpfRow row = new EnhancedWpfRow();
                    row.WrapReady(control);
                    list.Add(row);
                }
                return list;
            }
        }

    }
}