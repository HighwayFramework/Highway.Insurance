using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfMenu
    /// </summary>
    public class EnhancedWpfMenu : EnhancedWpfControl<WpfMenu>
    {
        public EnhancedWpfMenu() : base() { }
        public EnhancedWpfMenu(string searchParameters) : base(searchParameters) { }

        public UITestControlCollection Items
        {
            get { return this.UnWrap().Items; }
        }

        public List<EnhancedWpfMenuItem> ItemsAsEnhanced
        {
            get
            {
                List<EnhancedWpfMenuItem> list = new List<EnhancedWpfMenuItem>();
                foreach (WpfMenuItem item in this.UnWrap().Items)
                {
                    EnhancedWpfMenuItem Item = new EnhancedWpfMenuItem();
                    Item.WrapReady(item);
                    list.Add(Item);
                }
                return list;
            }
        }

        public List<string> ItemsAsList
        {
            get { return (this.UnWrap().Items.Select(x => ((WpfMenuItem) x).Header)).ToList<string>(); }
        }

    }
}