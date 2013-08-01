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
                this._control.WaitForControlReady();
                
                IEnhancedWinControl ret = null;
                
                try
                {
                    ret = EnhancedWinControlFactory.Create((WinControl)this._control.GetParent());
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
        public IEnhancedWinControl PreviousSibling
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedWinControl ret = null;
                try
                {
                    ret = WrapUtil((WinControl)this._control.GetParent().GetChildren()[GetMyIndexAmongSiblings() - 1]);
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
        public IEnhancedWinControl NextSibling
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedWinControl ret = null;
                try
                {
                    UITestControl parent = this._control.GetParent();

                    UITestControlCollection children = parent.GetChildren();

                    int thisIndex = GetMyIndexAmongSiblings();

                    UITestControl child = children[thisIndex + 1];

                    ret = WrapUtil((WinControl)child);
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
        public IEnhancedWinControl FirstChild
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedWinControl ret = null;
                try
                {
                    ret = WrapUtil((WinControl)this._control.GetChildren()[0]);
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
        public List<IEnhancedWinControl> GetChildren()
        {
            this._control.WaitForControlReady();
            var uicol = new List<IEnhancedWinControl>();
            foreach (UITestControl uitestcontrol in this._control.GetChildren())
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

    }
}
