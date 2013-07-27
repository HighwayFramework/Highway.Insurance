using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinMenu
    /// </summary>
    public class EnhancedWinMenu : EnhancedWinControl<WinMenu>
    {
        public EnhancedWinMenu() : base() { }
        public EnhancedWinMenu(string searchParameters) : base(searchParameters) { }

        public UITestControlCollection Items
        {
            get { return this.UnWrap().Items; }
        }

        public List<EnhancedWinMenuItem> ItemsAsEnhanced
        {
            get
            {
                List<EnhancedWinMenuItem> list = new List<EnhancedWinMenuItem>();
                foreach (WinMenuItem item in this.UnWrap().Items)
                {
                    EnhancedWinMenuItem Item = new EnhancedWinMenuItem();
                    Item.WrapReady(item);
                    list.Add(Item);
                }
                return list;
            }
        }

        public List<string> ItemsAsList
        {
            get { return (this.UnWrap().Items.Select(x => ((WinMenuItem) x).DisplayText)).ToList<string>(); }
        }
    }
}