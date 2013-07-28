using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfTreeItem
    /// </summary>
    public class EnhancedWpfTreeItem : EnhancedWpfControl<WpfTreeItem>
    {
        public EnhancedWpfTreeItem() : base() { }
        public EnhancedWpfTreeItem(string searchParameters) : base(searchParameters) { }

        public bool Expanded
        {
            get { return this.UnWrap().Expanded; }
            set { this.UnWrap().Expanded = value; }
        }

        public bool HasChildNodes
        {
            get { return this.UnWrap().HasChildNodes; }
        }

        public string Header
        {
            get { return this.UnWrap().Header; }
        }

        public UITestControlCollection Nodes
        {
            get { return this.UnWrap().Nodes; }
        }

        public List<EnhancedWpfTreeItem> NodesAsEnhanced
        {
            get
            {
                List<EnhancedWpfTreeItem> list = new List<EnhancedWpfTreeItem>();
                foreach (WpfTreeItem node in this.UnWrap().Nodes)
                {
                    EnhancedWpfTreeItem Item = new EnhancedWpfTreeItem();
                    Item.WrapReady(node);
                    list.Add(Item);
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