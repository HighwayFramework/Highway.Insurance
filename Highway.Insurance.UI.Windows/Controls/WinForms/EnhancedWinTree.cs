using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinTree
    /// </summary>
    public class EnhancedWinTree : EnhancedWinControl<WinTree>
    {
        public EnhancedWinTree() : base() { }
        public EnhancedWinTree(string searchParameters) : base(searchParameters) { }

        public UITestControl HorizontalScrollBar
        {
            get { return this.UnWrap().HorizontalScrollBar; }
        }

        public UITestControlCollection Nodes
        {
            get { return this.UnWrap().Nodes; }
        }

        public List<EnhancedWinTreeItem> NodesAsEnhanced
        {
            get
            {
                List<EnhancedWinTreeItem> list = new List<EnhancedWinTreeItem>();
                foreach (WinTreeItem node in this.UnWrap().Nodes)
                {
                    EnhancedWinTreeItem Item = new EnhancedWinTreeItem();
                    Item.WrapReady(node);
                    list.Add(Item);
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