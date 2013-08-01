using System;
using System.Collections.Generic;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Base wrapper class for all Highway.Insurance _Wpf* controls, inherits from Highway.Insurance _ControlBase
    /// </summary>
    /// <typeparam name="T">The Coded UI WpfControl type</typeparam>
    public class EnhancedWpfControl<T> : EnhancedControlBase<T>, IEnhancedWpfControl where T : WpfControl
    {
        public EnhancedWpfControl() : base() { }
        public EnhancedWpfControl(string searchParameters) : base(searchParameters) { }

        /// <summary>
        /// Gets the parent of the current  control.
        /// </summary>
        public IEnhancedWpfControl Parent
        {
            get
            {
                this._control.WaitForControlReady();

                IEnhancedWpfControl ret = null;

                try
                {
                    ret = EnhancedWpfControlFactory.Create((WpfControl)this._control.GetParent());
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).Parent", this._control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the previous sibling of the current Highway.Insurance control.
        /// </summary>
        public IEnhancedWpfControl PreviousSibling
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedWpfControl ret = null;
                try
                {
                    ret = WrapUtil((WpfControl)this._control.GetParent().GetChildren()[GetMyIndexAmongSiblings() - 1]);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).PreviousSibling", this._control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the next sibling of the current Highway.Insurance control.
        /// </summary>
        public IEnhancedWpfControl NextSibling
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedWpfControl ret = null;
                try
                {
                    UITestControl parent = this._control.GetParent();

                    UITestControlCollection children = parent.GetChildren();

                    int thisIndex = GetMyIndexAmongSiblings();

                    UITestControl child = children[thisIndex + 1];

                    ret = WrapUtil((WpfControl)child);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).NextSibling", this._control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the first child of the current Highway.Insurance control.
        /// </summary>
        public IEnhancedWpfControl FirstChild
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedWpfControl ret = null;
                try
                {
                    ret = WrapUtil((WpfControl)this._control.GetChildren()[0]);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).FirstChild", this._control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Returns a list of all first level children of the current Highway.Insurance control.
        /// </summary>
        /// <returns>list of all first level children</returns>
        public List<IEnhancedWpfControl> GetChildren()
        {
            this._control.WaitForControlReady();
            var uicol = new List<IEnhancedWpfControl>();
            foreach (UITestControl uitestcontrol in this._control.GetChildren())
            {
                uicol.Add(WrapUtil((WpfControl)uitestcontrol));
            }
            return uicol;
        }


        private static IEnhancedWpfControl WrapUtil(WpfControl control)
        {
            IEnhancedWpfControl _con = null;
            if (control.GetType() == typeof(WpfButton))
            {
                _con = new EnhancedWpfButton();
            }
            else if (control.GetType() == typeof(WpfCheckBox))
            {
                _con = new EnhancedWpfCheckBox();
            }
            else if (control.GetType() == typeof(WpfComboBox))
            {
                _con = new EnhancedWpfComboBox();
            }
            else if (control.GetType() == typeof(WpfEdit))
            {
                _con = new EnhancedWpfEdit();
            }
            else if (control.GetType() == typeof(WpfHyperlink))
            {
                _con = new EnhancedWpfHyperlink();
            }
            else if (control.GetType() == typeof(WpfList))
            {
                _con = new EnhancedWpfList();
            }
            else if (control.GetType() == typeof(WpfListItem))
            {
                _con = new EnhancedWpfListItem();
            }
            else if (control.GetType() == typeof(WpfRadioButton))
            {
                _con = new EnhancedWpfRadioButton();
            }
            else if (control.GetType() == typeof(WpfTable))
            {
                _con = new EnhancedWpfTable();
            }
            else if (control.GetType() == typeof(WpfCell))
            {
                _con = new EnhancedWpfCell();
            }
            else if (control.GetType() == typeof(WpfScrollBar))
            {
                _con = new EnhancedWpfScrollBar();
            }
            else if (control.GetType() == typeof(WpfCustom))
            {
                _con = new EnhancedWpfCustom();
            }
            else
            {
                throw new Exception(string.Format("WrapUtil: '{0}' not supported", control.GetType().Name));
            }
            _con.WrapReady(control);
            return _con;
        }

        private int GetMyIndexAmongSiblings()
        {
            int i = -1;
            foreach (UITestControl uitestcontrol in this._control.GetParent().GetChildren())
            {
                i++;
                if (uitestcontrol == this._control)
                {
                    break;
                }
            }
            return i;
        }

        /// <summary>
        /// Wrap AcceleratorKey property common to all WPF controls
        /// </summary>
        public string AcceleratorKey
        {
            get { return this.UnWrap().AcceleratorKey; }
        }

        /// <summary>
        /// Wrap AccessKey property common to all WPF controls
        /// </summary>
        public string AccessKey
        {
            get { return this.UnWrap().AccessKey; }
        }

        /// <summary>
        /// Wrap AutomationId property common to all WPF controls
        /// </summary>
        public string AutomationId
        {
            get { return this.UnWrap().AutomationId; }
        }

        /// <summary>
        /// Wrap Font property common to all WPF controls
        /// </summary>
        public string Font
        {
            get { return this.UnWrap().Font; }
        }

        /// <summary>
        /// Wrap HelpText property common to all WPF controls
        /// </summary>
        public string HelpText
        {
            get { return this.UnWrap().HelpText; }
        }

        /// <summary>
        /// Wrap LabeledBy property common to all WPF controls
        /// </summary>
        public string LabeledBy
        {
            get { return this.UnWrap().LabeledBy; }
        }
    }
}
