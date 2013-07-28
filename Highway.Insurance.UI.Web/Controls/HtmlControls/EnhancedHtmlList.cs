using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class EnhancedHtmlList : EnhancedHtmlControl<HtmlList>
    {
        public EnhancedHtmlList() : base() { }
        public EnhancedHtmlList(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlList(WebPage page, string selector) : base(page, selector) { }
        public EnhancedHtmlList(HtmlList control) : base(control) { }

        /// <summary>
        /// Gets the items in a string array of the html list.
        /// </summary>
        public string[] Items
        {
            get
            {
                //trying to call InnerText of children will cause errors if child items are disabled
                return InnerText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        /// <summary>
        /// Tells whether the specified item is present in the html list or not.
        /// </summary>
        public bool ItemExists(string sText)
        {
            return this.Items.Contains<string>(sText);
        }

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        /// <value>
        /// The selected items.
        /// </value>
        public string[] SelectedItems
        {
            get
            {
                this._control.WaitForControlReady();
                return _control.SelectedItems;
            }
            set
            {
                this._control.WaitForControlReady();
                _control.SelectedItems = value;
            }
        }
    }
}
