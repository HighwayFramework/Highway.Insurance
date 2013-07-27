using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinMenuBar
    /// </summary>
    public class EnhancedWinMenuBar : EnhancedWinControl<WinMenuBar>
    {
        public EnhancedWinMenuBar() : base() { }
        public EnhancedWinMenuBar(string searchParameters) : base(searchParameters) { }

        public UITestControlCollection Items
        {
            get { return this.UnWrap().Items; }
        }

        public List<EnhancedWinMenuItem> ItemsAsCUITe
        {
            get
            {
                List<EnhancedWinMenuItem> list = new List<EnhancedWinMenuItem>();
                foreach (WinMenuItem item in this.UnWrap().Items)
                {
                    EnhancedWinMenuItem cuiteItem = new EnhancedWinMenuItem();
                    cuiteItem.WrapReady(item);
                    list.Add(cuiteItem);
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