using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfRow
    /// </summary>
    public class EnhancedWpfRow : EnhancedWpfControl<WpfRow>
    {
        public EnhancedWpfRow() : base() { }
        public EnhancedWpfRow(string searchParameters) : base(searchParameters) { }

        public bool CanSelectMultiple
        {
            get { return this.UnWrap().CanSelectMultiple; }
        }

        public UITestControlCollection Cells
        {
            get { return this.UnWrap().Cells; }
        }

        public List<EnhancedWpfCell> CellsAsEnhanced
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

        public UITestControl Header
        {
            get { return this.UnWrap().Header; }
        }

        public int RowIndex
        {
            get { return this.UnWrap().RowIndex; }
        }

        public bool Selected
        {
            get { return this.UnWrap().Selected; }
        }
    }
}