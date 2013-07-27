using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinTreeItem
    /// </summary>
    public class EnhancedWinTreeItem : EnhancedWinControl<WinTreeItem>
    {
        public EnhancedWinTreeItem() : base() { }
        public EnhancedWinTreeItem(string searchParameters) : base(searchParameters) { }

        public bool Expanded
        {
            get { return this.UnWrap().Expanded; }
            set { this.UnWrap().Expanded = value; }
        }

        public bool HasChildNodes
        {
            get { return this.UnWrap().HasChildNodes; }
        }

        public UITestControlCollection Nodes
        {
            get { return this.UnWrap().Nodes; }
        }

        public List<EnhancedWinTreeItem> NodesAsCUITe
        {
            get
            {
                List<EnhancedWinTreeItem> list = new List<EnhancedWinTreeItem>();
                foreach (WinTreeItem node in this.UnWrap().Nodes)
                {
                    EnhancedWinTreeItem cuiteItem = new EnhancedWinTreeItem();
                    cuiteItem.WrapReady(node);
                    list.Add(cuiteItem);
                }
                return list;
            }
        }

        public UITestControl ParentNode
        {
            get { return this.UnWrap().ParentNode; }
        }

        public bool Selected
        {
            get { return this.UnWrap().Selected; }
            set { this.UnWrap().Selected = value; }
        }
    }
}