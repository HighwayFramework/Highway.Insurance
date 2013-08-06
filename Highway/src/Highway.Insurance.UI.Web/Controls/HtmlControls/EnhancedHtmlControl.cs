using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
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
        internal WebPage Page { get; set; }
        internal string Selector { get; set; }

        protected override T Control
        {
            get
            {
                JqueryControlPrep();
                return _control;
            }
            set
            {
                _control = value;
            }
        }

        public EnhancedHtmlControl()
            : base()
        {
        }

        public EnhancedHtmlControl(string searchParameters)
            : base(searchParameters)
        {
        }

        public EnhancedHtmlControl(WebPage page, string selector)
            : base()
        {
            Page = page;
            Selector = selector;
            controlFunc = () => page.FindControlBySelector<T>(selector);
        }

        public EnhancedHtmlControl(HtmlControl control)
        {
            Control = (T)control;
        }

        /// <summary>
        /// Searches in the current control for a control that matches the search parameters
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="searchParameters"></param>
        /// <returns></returns>
        public new T1 Get<T1>(string searchParameters) where T1 : IEnhancedHtmlControl
        {
            if (string.IsNullOrWhiteSpace(Selector))
            {
                return base.Get<T1>(searchParameters);
            }
            string selector = string.Format("{0} {1}", Selector, searchParameters);
            var control = EnhancedHtmlControlBaseFactory.Create<T1>(Page, selector);
            var baseControl = Page.FindControlBySelector(control.GetBaseType(), selector);
            control.Wrap(baseControl, false);
            return control;
        }

        /// <summary>
        /// Finds controls inside the current control that match the search criteria
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="elementSelector"></param>
        /// <returns></returns>
        public IEnumerable<T1> Find<T1>(string elementSelector) where T1 : IEnhancedHtmlControl
        {
            string selector = string.Format("{0} {1}", Selector, elementSelector);
            T1 control = EnhancedHtmlControlBaseFactory.Create<T1>(Page, selector);
            var baseControls = Page.FindControlsBySelector(control.GetBaseType(), selector);
            return baseControls.Select(x =>
            {
                var c = EnhancedHtmlControlBaseFactory.Create<T1>(Page, selector);
                c.Wrap(x, false);
                return c;
            });
        }

        /// <summary>
        /// Check this control and the parent chain for display: none
        /// </summary>
        public bool IsVisible()
        {
            if (!string.IsNullOrWhiteSpace(Selector)) return Page.IsVisible(Selector);
            Control.WaitForControlReady();
            return !_visibilitySearchPatterns.Any(x => x.IsMatch(Control.ControlDefinition));
        }

        /// <summary>
        /// Parses the data attributes from the html to get data values
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> Data()
        {
            
            this.Control.WaitForControlReady();
            var data = ParseDataFromDefintion();
            return data;
        }

        /// <summary>
        /// Gets the text content of this control.
        /// </summary>
        public string InnerText
        {
            get
            {
                
                this.Control.WaitForControlReady();
                return this.Control.InnerText;
            }
        }

        /// <summary>
        /// Gets the value of the Help Text attribute of this control.
        /// </summary>
        public string HelpText
        {
            get
            {
                
                this.Control.WaitForControlReady();
                return this.Control.HelpText;
            }
        }

        /// <summary>
        /// Gets the value of the Title attribute of this control.
        /// </summary>
        public string Title
        {
            get
            {
                 
                this.Control.WaitForControlReady();
                return this.Control.Title;
            }
        }

        /// <summary>
        /// Gets the value of the Value attribute of this control.
        /// </summary>
        public string ValueAttribute
        {
            get
            {
                
                this.Control.WaitForControlReady();
                return this.Control.ValueAttribute;
            }
        }

        /// <summary>
        /// Gets the value of the AccessKey attribute of this control.
        /// </summary>
        public string AccessKey
        {
            get
            {
                
                this.Control.WaitForControlReady();
                return this.Control.AccessKey;
            }
        }

        public bool CurrentlyExists()
        {
            return Page.CurrentlyExists(this);
        }

        /// <summary>
        /// Gets the parent of the current Highway.Insurance control.
        /// </summary>
        public IEnhancedHtmlControl Parent
        {
            get
            {
                IEnhancedHtmlControl ret = null;
                try
                {
                    ret = WrapUtil(GetParent());
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
        public IEnhancedHtmlControl PreviousSibling
        {
            get
            {
                IEnhancedHtmlControl ret = null;
                try
                {
                    ret = WrapUtil(GetPreviousSibling());
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
        public IEnhancedHtmlControl NextSibling
        {
            get
            {
                IEnhancedHtmlControl ret = null;
                try
                {
                    ret = WrapUtil(GetNextSibling());
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
        public IEnhancedHtmlControl FirstChild
        {
            get
            {
                IEnhancedHtmlControl ret = null;
                try
                {
                    ret = WrapUtil(GetFirstChild());
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
        public List<IEnhancedHtmlControl> GetChildren()
        {
            this.Control.WaitForControlReady();
            var children = GetChildrenControls();
            return children.Select(WrapUtil).ToList();
        }

        private static IEnhancedHtmlControl WrapUtil(HtmlControl control)
        {
            IEnhancedHtmlControl con = null;
            if (control.GetType() == typeof(HtmlButton))
            {
                con = new EnhancedHtmlButton();
            }
            else if (control.GetType() == typeof(HtmlCheckBox))
            {
                con = new EnhancedHtmlCheckBox();
            }
            else if (control.GetType() == typeof(HtmlComboBox))
            {
                con = new EnhancedHtmlComboBox();
            }
            else if (control.GetType() == typeof(HtmlDiv))
            {
                con = new EnhancedHtmlDiv();
            }
            else if (control.GetType() == typeof(HtmlEdit) && (string.Compare(control.Type, "password", true) == 0))
            {
                con = new EnhancedHtmlPassword();
            }
            else if (control.GetType() == typeof(HtmlEdit))
            {
                con = new EnhancedHtmlEdit();
            }
            else if (control.GetType() == typeof(HtmlEditableDiv))
            {
                con = new EnhancedHtmlEditableDiv();
            }
            else if (control.GetType() == typeof(HtmlFileInput))
            {
                con = new EnhancedHtmlFileInput();
            }
            else if (control.GetType() == typeof(HtmlHyperlink))
            {
                con = new EnhancedHtmlHyperlink();
            }
            else if (control.GetType() == typeof(HtmlImage))
            {
                con = new EnhancedHtmlImage();
            }
            else if (control.GetType() == typeof(HtmlInputButton))
            {
                con = new EnhancedHtmlInputButton();
            }
            else if (control.GetType() == typeof(HtmlLabel))
            {
                con = new EnhancedHtmlLabel();
            }
            else if (control.GetType() == typeof(HtmlList))
            {
                con = new EnhancedHtmlList();
            }
            else if (control.GetType() == typeof(HtmlListItem))
            {
                con = new EnhancedHtmlListItem();
            }
            else if (control.GetType() == typeof(HtmlRadioButton))
            {
                con = new EnhancedHtmlRadioButton();
            }
            else if (control.GetType() == typeof(HtmlSpan))
            {
                con = new EnhancedHtmlSpan();
            }
            else if (control.GetType() == typeof(HtmlEditableSpan))
            {
                con = new EnhancedHtmlEditableSpan();
            }
            else if (control.GetType() == typeof(HtmlTable))
            {
                con = new EnhancedHtmlTable();
            }
            else if (control.GetType() == typeof(HtmlCell))
            {
                con = new EnhancedHtmlCell();
            }
            else if (control.GetType() == typeof(HtmlTextArea))
            {
                con = new EnhancedHtmlTextArea();
            }
            else if (control.GetType() == typeof(HtmlScrollBar))
            {
                con = new EnhancedHtmlScrollBar();
            }
            else if (control.GetType() == typeof(HtmlTextArea))
            {
                con = new EnhancedHtmlTextArea();
            }
            else if (control.GetType() == typeof(HtmlCustom))
            {
                switch (control.TagName.ToLower())
                {
                    case "p":
                        con = new EnhancedHtmlParagraph();
                        break;
                    case "h1":
                        con = new EnhancedHtmlHeading1();
                        break;
                    case "h2":
                        con = new EnhancedHtmlHeading2();
                        break;
                    case "h3":
                        con = new EnhancedHtmlHeading3();
                        break;
                    case "h4":
                        con = new EnhancedHtmlHeading4();
                        break;
                    case "h5":
                        con = new EnhancedHtmlHeading5();
                        break;
                    case "h6":
                        con = new EnhancedHtmlHeading6();
                        break;
                    case "ul":
                        con = new EnhancedHtmlUnorderedList();
                        break;
                    case "ol":
                        con = new EnhancedHtmlOrderedList();
                        break;
                    case "ins":
                        con = new EnhancedHtmlIns();
                        break;
                    default:
                        con = new EnhancedHtmlCustom(control.TagName);
                        break;
                }
            }
            else
            {
                throw new Exception(string.Format("WrapUtil: '{0}' not supported", control.GetType().Name));
            }
            con.WrapReady(control);
            return con;
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

        private readonly List<Regex> _visibilitySearchPatterns = new List<Regex>()
        {
            new Regex(@"\s*display\s*:\s*none.*"),
            new Regex(@"\s*visiblity\s*:\s*hidden.*")
        };

        private Regex dataParameterSearch = new Regex("data-\\w+=\"[^\"]+\"");

        private Func<T> controlFunc;

        private Dictionary<string, string> ParseDataFromDefintion()
        {
            MatchCollection dataAttributes = dataParameterSearch.Matches(this.Control.ControlDefinition);
            var data = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            foreach (object dataAttribute in dataAttributes)
            {
                var stringData = dataAttribute.ToString();
                var stringSplit = stringData.Split('=');
                if (stringSplit.Length != 2) continue;
                var key = stringSplit[0].ToLowerInvariant().Replace("data-", string.Empty);
                var value = stringSplit[1].Replace("\"", string.Empty);
                data.Add(key, value);
            }
            return data;
        }

        private void JqueryControlPrep()
        {
            if (controlFunc != null)
            {
                T con = null;
                con = controlFunc();
                if (con == null)
                {
                    throw new HighwayInsuranceNoControlFound(string.Format("No control for JQuery Selector : {0}", Selector));
                }
                _control = con;
            }
        }


        private HtmlControl GetParent()
        {
            HtmlControl parent;
            if (string.IsNullOrWhiteSpace(Selector))
            {
                parent = Page.GetParent(Selector);
            }
            else
            {
                this.Control.WaitForControlReady();
                parent = (HtmlControl)this.Control.GetParent();
            }
            return parent;
        }

        private HtmlControl GetPreviousSibling()
        {
            HtmlControl sibling;
            if (string.IsNullOrWhiteSpace(Selector))
            {
                sibling = Page.GetParent(Selector);
            }
            else
            {
                this.Control.WaitForControlReady();
                sibling = (HtmlControl)this.Control.GetParent().GetChildren()[GetMyIndexAmongSiblings() - 1];
            }
            return sibling;

        }

        public HtmlControl GetNextSibling()
        {
            HtmlControl sibling;
            if (string.IsNullOrWhiteSpace(Selector))
            {
                sibling = Page.GetParent(Selector);
            }
            else
            {
                this.Control.WaitForControlReady();
                sibling = (HtmlControl)this.Control.GetParent().GetChildren()[GetMyIndexAmongSiblings() + 1];
            }
            return sibling;
        }

        private HtmlControl GetFirstChild()
        {
            HtmlControl firstChild;
            if (string.IsNullOrWhiteSpace(Selector))
            {
                firstChild = Page.GetFirstChild(Selector);
            }
            else
            {
                this.Control.WaitForControlReady();
                firstChild = (HtmlControl)this.Control.GetParent().GetChildren()[0];
            }
            return firstChild;
        }

        private IEnumerable<HtmlControl> GetChildrenControls()
        {
            List<HtmlControl> children = new List<HtmlControl>();
            if (string.IsNullOrWhiteSpace(Selector))
            {
                children.AddRange(Page.GetChildControls(Selector));
            }
            else
            {
                this.Control.WaitForControlReady();
                children.AddRange(this.Control.GetParent().GetChildren().Select(x=> (HtmlControl)x));
            }
            return children;
        }

    }
}
