using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfTabList
    /// </summary>
    public class EnhancedWpfTabList : EnhancedWpfControl<WpfTabList>
    {
        public EnhancedWpfTabList() : base() { }
        public EnhancedWpfTabList(string searchParameters) : base(searchParameters) { }

        public int SelectedIndex
        {
            get { return this.UnWrap().SelectedIndex; }
            set { this.UnWrap().SelectedIndex = value; }
        }

        public UITestControlCollection Tabs
        {
            get { return this.UnWrap().Tabs; }
        }

        public List<EnhancedWpfTabPage> TabsAsEnhanced
        {
            get
            {
                List<EnhancedWpfTabPage> list = new List<EnhancedWpfTabPage>();
                foreach (WpfTabPage control in this.UnWrap().Tabs)
                {
                    EnhancedWpfTabPage tab = new EnhancedWpfTabPage();
                    tab.WrapReady(control);
                    list.Add(tab);
                }
                return list;
            }
        }

    }
}