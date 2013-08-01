using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    /// <summary>
    /// Highway.Insurance wrapper for HtmlComboBox.
    /// </summary>
    public class EnhancedHtmlComboBox : EnhancedHtmlControl<HtmlComboBox>
    {
        public EnhancedHtmlComboBox() : base() { }
        public EnhancedHtmlComboBox(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlComboBox(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlComboBox(HtmlComboBox control) : base(control) { }

        /// <summary>
        /// Selects the item in the combobox.
        /// </summary>
        /// <param name="sItem">Item as string</param>
        public void SelectItem(string sItem)
        {
            this.Control.WaitForControlReady();
            this.Control.SelectedItem = sItem;
        }

        /// <summary>
        /// Selects the item in the combobox by index.
        /// </summary>
        /// <param name="index">index of item</param>
        public void SelectItem(int index)
        {
            this.Control.WaitForControlReady();
            this.Control.SelectedIndex = index;
        }

        /// <summary>
        /// Gets the selected item in a combobox.
        /// </summary>
        public string SelectedItem
        {
            get 
            {
                this.Control.WaitForControlReady();
                return this.Control.SelectedItem; 
            }
        }

        /// <summary>
        /// Gets the selected index in a combobox.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                this.Control.WaitForControlReady();
                return this.Control.SelectedIndex;
            }
        }

        /// <summary>
        /// Gets the count of the items in the combobox.
        /// </summary>
        public int ItemCount
        {
            get
            {
                this.Control.WaitForControlReady();
                return this.Control.ItemCount;
            }
        }

        /// <summary>
        /// Gets the items in a string array of the html combo box.
        /// </summary>
        public string[] Items
        {
            get
            {
                //trying to call InnerText of children will cause errors if child items are disabled
                return InnerText.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        /// <summary>
        /// Tells whether the specified item is present in the html combo box or not.
        /// </summary>
        public bool ItemExists(string sText)
        {
            return this.Items.Contains<string>(sText);
        }
    }
}
