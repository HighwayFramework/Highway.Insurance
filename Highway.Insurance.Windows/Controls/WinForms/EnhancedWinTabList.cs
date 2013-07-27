using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Wrapper class for WinTabList
    /// </summary>
    public class EnhancedWinTabList : EnhancedWinControl<WinTabList>
    {
        public EnhancedWinTabList() : base() { }
        public EnhancedWinTabList(string searchParameters) : base(searchParameters) { }

        public int SelectedIndex
        {
            get { return this.UnWrap().SelectedIndex; }
            set { this.UnWrap().SelectedIndex = value; }
        }

        public UITestControlCollection Tabs
        {
            get { return this.UnWrap().Tabs; }
        }

        public List<EnhancedWinTabPage> TabsAsCUITe
        {
            get
            {
                List<EnhancedWinTabPage> list = new List<EnhancedWinTabPage>();
                foreach (WinTabPage control in this.UnWrap().Tabs)
                {
                    EnhancedWinTabPage tab = new EnhancedWinTabPage();
                    tab.WrapReady(control);
                    list.Add(tab);
                }
                return list;
            }
        }

        public UITestControl TabSpinner
        {
            get { return this.UnWrap().TabSpinner; }
        }

    }
}