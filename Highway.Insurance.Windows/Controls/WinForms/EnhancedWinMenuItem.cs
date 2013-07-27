using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinMenuItem
    /// </summary>
    public class EnhancedWinMenuItem : EnhancedWinControl<WinMenuItem>
    {
        public EnhancedWinMenuItem() : base() { }
        public EnhancedWinMenuItem(string searchParameters) : base(searchParameters) { }

        public bool Checked
        {
            get { return this.UnWrap().Checked; }
            set { this.UnWrap().Checked = value; }
        }

        public string DisplayText
        {
            get { return this.UnWrap().DisplayText; }
        }

        public bool HasChildNodes
        {
            get { return this.UnWrap().HasChildNodes; }
        }

        public bool IsTopLevelMenu
        {
            get { return this.UnWrap().IsTopLevelMenu; }
        }

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

        public string Shortcut
        {
            get { return this.UnWrap().Shortcut; }
        }

    }
}