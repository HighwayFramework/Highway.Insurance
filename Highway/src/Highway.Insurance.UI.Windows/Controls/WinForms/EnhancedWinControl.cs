using System;
using System.Collections.Generic;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Base wrapper class for all _Win* controls, inherits from _ControlBase
    /// </summary>
    /// <typeparam name="T">The Coded UI WinControl type</typeparam>
    public class EnhancedWinControl<T> : EnhancedControlBase<T>, IEnhancedWinControl where T : WinControl
    {
        public EnhancedWinControl() : base() { }
        public EnhancedWinControl(string searchParameters) : base(searchParameters) { }

        /// <summary>
        /// Gets the parent of the current  control.
        /// </summary>
        public IEnhancedWinControl Parent
        {
            get
            {
                this.Control.WaitForControlReady();
                
                IEnhancedWinControl ret = null;
                
                try
                {
                    ret = EnhancedWinControlFactory.Create((WinControl)this.Control.GetParent());
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).Parent", this.Control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the previous sibling of the current Highway.Insurance control.
        /// </summary>
        public IEnhancedWinControl PreviousSibling
        {
            get
            {
                this.Control.WaitForControlReady();
                IEnhancedWinControl ret = null;
                try
                {
                    ret = WrapUtil((WinControl)this.Control.GetParent().GetChildren()[GetMyIndexAmongSiblings() - 1]);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).PreviousSibling", this.Control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the next sibling of the current Highway.Insurance control.
        /// </summary>
        public IEnhancedWinControl NextSibling
        {
            get
            {
                this.Control.WaitForControlReady();
                IEnhancedWinControl ret = null;
                try
                {
                    UITestControl parent = this.Control.GetParent();

                    UITestControlCollection children = parent.GetChildren();

                    int thisIndex = GetMyIndexAmongSiblings();

                    UITestControl child = children[thisIndex + 1];

                    ret = WrapUtil((WinControl)child);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).NextSibling", this.Control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the first child of the current Highway.Insurance control.
        /// </summary>
        public IEnhancedWinControl FirstChild
        {
            get
            {
                this.Control.WaitForControlReady();
                IEnhancedWinControl ret = null;
                try
                {
                    ret = WrapUtil((WinControl)this.Control.GetChildren()[0]);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).FirstChild", this.Control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Returns a list of all first level children of the current Highway.Insurance control.
        /// </summary>
        /// <returns>list of all first level children</returns>
        public List<IEnhancedWinControl> GetChildren()
        {
            this.Control.WaitForControlReady();
            var uicol = new List<IEnhancedWinControl>();
            foreach (UITestControl uitestcontrol in this.Control.GetChildren())
            {
                uicol.Add(WrapUtil((WinControl)uitestcontrol));
            }
            return uicol;
        }


        private static IEnhancedWinControl WrapUtil(WinControl control)
        {
            IEnhancedWinControl _con = null;
            if (control.GetType() == typeof(WinButton))
            {
                _con = new EnhancedWinButton();
            }
            else if (control.GetType() == typeof(WinCheckBox))
            {
                _con = new EnhancedWinCheckBox();
            }
            else if (control.GetType() == typeof(WinComboBox))
            {
                _con = new EnhancedWinComboBox();
            }
            else if (control.GetType() == typeof(WinEdit))
            {
                _con = new EnhancedWinEdit();
            }
            else if (control.GetType() == typeof(WinHyperlink))
            {
                _con = new EnhancedWinHyperlink();
            }
            else if (control.GetType() == typeof(WinList))
            {
                _con = new EnhancedWinList();
            }
            else if (control.GetType() == typeof(WinListItem))
            {
                _con = new EnhancedWinListItem();
            }
            else if (control.GetType() == typeof(WinRadioButton))
            {
                _con = new EnhancedWinRadioButton();
            }
            else if (control.GetType() == typeof(WinTable))
            {
                _con = new EnhancedWinTable();
            }
            else if (control.GetType() == typeof(WinCell))
            {
                _con = new EnhancedWinCell();
            }
            else if (control.GetType() == typeof(WinScrollBar))
            {
                _con = new EnhancedWinScrollBar();
            }
            else if (control.GetType() == typeof(WinCustom))
            {
                _con = new EnhancedWinCustom();
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
            foreach (UITestControl uitestcontrol in this.Control.GetParent().GetChildren())
            {
                i++;
                if (uitestcontrol == this.Control)
                {
                    break;
                }
            }
            return i;
        }

    }
}
