using System;
using System.Collections.Generic;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    /// <summary>
    /// Base class for all Highway.Insurance _Html controls, inherits from Highway.Insurance _ControlBase
    /// </summary>
    /// <typeparam name="T">The Coded UI Test Html control type</typeparam>
    public class EnhancedHtmlControl<T> : EnhancedControlBase<T>, IEnhancedHtmlControl
        where T : HtmlControl
    {
        public EnhancedHtmlControl()
            : base()
        {
        }

        public EnhancedHtmlControl(string searchParameters)
            : base(searchParameters)
        {
        }

        public EnhancedHtmlControl(HtmlControl control)
            : base()
        {
            this._control = (T)control;
        }

        /// <summary>
        /// Gets the text content of this control.
        /// </summary>
        public string InnerText
        {
            get
            {
                this._control.WaitForControlReady();
                return this._control.InnerText;
            }
        }

        /// <summary>
        /// Gets the value of the Help Text attribute of this control.
        /// </summary>
        public string HelpText
        {
            get
            {
                this._control.WaitForControlReady();
                return this._control.HelpText;
            }
        }

        /// <summary>
        /// Gets the value of the Title attribute of this control.
        /// </summary>
        public string Title
        {
            get
            {
                this._control.WaitForControlReady();
                return this._control.Title;
            }
        }

        /// <summary>
        /// Gets the value of the Value attribute of this control.
        /// </summary>
        public string ValueAttribute
        {
            get
            {
                this._control.WaitForControlReady();
                return this._control.ValueAttribute;
            }
        }

        /// <summary>
        /// Gets the value of the AccessKey attribute of this control.
        /// </summary>
        public string AccessKey
        {
            get
            {
                this._control.WaitForControlReady();
                return this._control.AccessKey;
            }
        }

        /// <summary>
        /// Gets the parent of the current Highway.Insurance  control.
        /// </summary>
        public override IEnhancedControlBase Parent
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedControlBase ret = null;
                try
                {
                    ret = WrapUtil((HtmlControl)this._control.GetParent());
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).Parent", this._control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the previous sibling of the current Highway.Insurance  control.
        /// </summary>
        public override IEnhancedControlBase PreviousSibling
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedControlBase ret = null;
                try
                {
                    ret = WrapUtil((HtmlControl)this._control.GetParent().GetChildren()[GetMyIndexAmongSiblings() - 1]);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).PreviousSibling", this._control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the next sibling of the current Highway.Insurance  control.
        /// </summary>
        public override IEnhancedControlBase NextSibling
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedControlBase ret = null;
                try
                {
                    UITestControl parent = this._control.GetParent();

                    UITestControlCollection children = parent.GetChildren();

                    int thisIndex = GetMyIndexAmongSiblings();

                    UITestControl child = children[thisIndex + 1];

                    ret = WrapUtil((HtmlControl)child);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).NextSibling", this._control.GetType().Name));
                }
                return ret;
            }
        }

        /// <summary>
        /// Gets the first child of the current Highway.Insurance  control.
        /// </summary>
        public override IEnhancedControlBase FirstChild
        {
            get
            {
                this._control.WaitForControlReady();
                IEnhancedControlBase ret = null;
                try
                {
                    ret = WrapUtil((HtmlControl)this._control.GetChildren()[0]);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).FirstChild", this._control.GetType().Name));
                }
                return ret;
            }
        }
        
        /// <summary>
        /// Returns a list of all first level children of the current Highway.Insurance  control.
        /// </summary>
        /// <returns>list of all first level children</returns>
        public override List<IEnhancedControlBase> GetChildren()
        {
            this._control.WaitForControlReady();
            var uicol = new List<IEnhancedControlBase>();
            foreach (UITestControl uitestcontrol in this._control.GetChildren())
            {
                uicol.Add(WrapUtil((HtmlControl)uitestcontrol));
            }
            return uicol;
        }

        private static IEnhancedControlBase WrapUtil(HtmlControl control)
        {
            IEnhancedControlBase _con = null;
            if (control.GetType() == typeof(HtmlButton))
            {
                _con = new EnhancedHtmlButton();
            }
            else if (control.GetType() == typeof(HtmlCheckBox))
            {
                _con = new EnhancedHtmlCheckBox();
            }
            else if (control.GetType() == typeof(HtmlComboBox))
            {
                _con = new EnhancedHtmlComboBox();
            }
            else if (control.GetType() == typeof(HtmlDiv))
            {
                _con = new EnhancedHtmlDiv();
            }
            else if (control.GetType() == typeof(HtmlEdit) && (string.Compare(control.Type, "password", true) == 0))
            {
                _con = new EnhancedHtmlPassword();
            }
            else if (control.GetType() == typeof(HtmlEdit))
            {
                _con = new EnhancedHtmlEdit();
            }
            else if (control.GetType() == typeof(HtmlEditableDiv))
            {
                _con = new EnhancedHtmlEditableDiv();
            }
            else if (control.GetType() == typeof(HtmlFileInput))
            {
                _con = new EnhancedHtmlFileInput();
            }
            else if (control.GetType() == typeof(HtmlHyperlink))
            {
                _con = new EnhancedHtmlHyperlink();
            }
            else if (control.GetType() == typeof(HtmlImage))
            {
                _con = new EnhancedHtmlImage();
            }
            else if (control.GetType() == typeof(HtmlInputButton))
            {
                _con = new EnhancedHtmlInputButton();
            }
            else if (control.GetType() == typeof(HtmlLabel))
            {
                _con = new EnhancedHtmlLabel();
            }
            else if (control.GetType() == typeof(HtmlList))
            {
                _con = new EnhancedHtmlList();
            }
            else if (control.GetType() == typeof (HtmlListItem))
            {
                _con = new EnhancedHtmlListItem();
            }
            else if (control.GetType() == typeof(HtmlRadioButton))
            {
                _con = new EnhancedHtmlRadioButton();
            }
            else if (control.GetType() == typeof(HtmlSpan))
            {
                _con = new EnhancedHtmlSpan();
            }
            else if (control.GetType() == typeof(HtmlEditableSpan))
            {
                _con = new EnhancedHtmlEditableSpan();
            }
            else if (control.GetType() == typeof(HtmlTable))
            {
                _con = new EnhancedHtmlTable();
            }
            else if (control.GetType() == typeof(HtmlCell))
            {
                _con = new EnhancedHtmlCell();
            }
            else if (control.GetType() == typeof(HtmlTextArea))
            {
                _con = new EnhancedHtmlTextArea();
            }
            else if (control.GetType() == typeof(HtmlScrollBar))
            {
                _con = new EnhancedHtmlScrollBar();
            }
            else if (control.GetType() == typeof(HtmlTextArea))
            {
                _con = new EnhancedHtmlTextArea();
            }
            else if (control.GetType() == typeof(HtmlCustom))
            {
                switch (control.TagName.ToLower())
                {
                    case "p":
                        _con = new EnhancedHtmlParagraph();
                        break;
                    case "h1":
                        _con = new EnhancedHtmlHeading1();
                        break;
                    case "h2":
                        _con = new EnhancedHtmlHeading2();
                        break;
                    case "h3":
                        _con = new EnhancedHtmlHeading3();
                        break;
                    case "h4":
                        _con = new EnhancedHtmlHeading4();
                        break;
                    case "h5":
                        _con = new EnhancedHtmlHeading5();
                        break;
                    case "h6":
                        _con = new EnhancedHtmlHeading6();
                        break;
                    case "ul":
                        _con = new EnhancedHtmlUnorderedList();
                        break;
                    case "ol":
                        _con = new EnhancedHtmlOrderedList();
                        break;
                    case "ins":
                        _con = new EnhancedHtmlIns();
                        break;
                    default:
                        _con = new EnhancedHtmlCustom(control.TagName);
                        break;
                }
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
