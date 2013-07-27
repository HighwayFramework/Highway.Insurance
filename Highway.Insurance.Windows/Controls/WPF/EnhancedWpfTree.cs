using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfTree
    /// </summary>
    public class EnhancedWpfTree : EnhancedWpfControl<WpfTree>
    {
        public EnhancedWpfTree() : base() { }
        public EnhancedWpfTree(string searchParameters) : base(searchParameters) { }

        public UITestControl HorizontalScrollBar
        {
            get { return this.UnWrap().HorizontalScrollBar; }
        }

        public UITestControlCollection Nodes
        {
            get { return this.UnWrap().Nodes; }
        }

        public List<EnhancedWpfTreeItem> NodesAsCUITe
        {
            get
            {
                List<EnhancedWpfTreeItem> list = new List<EnhancedWpfTreeItem>();
                foreach (WpfTreeItem node in this.UnWrap().Nodes)
                {
                    EnhancedWpfTreeItem cuiteItem = new EnhancedWpfTreeItem();
                    cuiteItem.WrapReady(node);
                    list.Add(cuiteItem);
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