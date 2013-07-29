using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Controls
{
    /// <summary>
    /// Base wrapper class for all Highway.Insurance * controls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnhancedControlBase<T> : IEnhancedControlBase
        where T : UITestControl
    {
        protected T _control;
        protected PropertyExpressionCollection SearchProperties;
        private string _jquerySelector; 
        private bool _isJquery;

        public EnhancedControlBase()
        {
            this.SearchProperties = new PropertyExpressionCollection();
        }

        public EnhancedControlBase(string searchProperties) : this()
        {
            if (String.IsNullOrWhiteSpace(searchProperties))
            {
                return;
            }
            SetupInstanceForCodedUISelector(searchProperties);
        }


        private void SetupInstanceForCodedUISelector(string searchProperties)
        {
            var controlProperties = GetAllPropertyNames();

            // Split on groups of key/value pairs
            string[] saKeyValuePairs = searchProperties.Split(new char[] {';'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (string sKeyValue in saKeyValuePairs)
            {
                PropertyExpressionOperator compareOperator = PropertyExpressionOperator.EqualTo;

                // If split on '=' does not work, then try '~'
                // Split at the first instance of '='. Other instances are considered part of the value.
                string[] saKeyVal = sKeyValue.Split(new char[] {'='}, 2);
                if (saKeyVal.Length != 2)
                {
                    // Otherwise try to split on '~'. If it works then compare type is Contains
                    // Split at the first instance of '~'. Other instances are considered part of the value.
                    saKeyVal = sKeyValue.Split(new char[] {'~'}, 2);
                    if (saKeyVal.Length == 2)
                    {
                        compareOperator = PropertyExpressionOperator.Contains;
                    }
                    else
                    {
                        throw new HighwayInsuranceInvalidSearchParameterFormat(searchProperties);
                    }
                }

                // Find the first property in the list of known values
                string valueName = saKeyVal[0];

                if ((typeof (T).IsSubclassOf(typeof (HtmlControl))) &&
                    (valueName.Equals("Value", StringComparison.OrdinalIgnoreCase)))
                {
                    //support for backward compatibility where search properties like "Value=Log In" are used
                    valueName += "Attribute";
                }

                FieldInfo foundField = controlProperties.Find(
                    searchProperty => searchProperty.Name.Equals(valueName, StringComparison.OrdinalIgnoreCase));

                if (foundField == null)
                {
                    throw new HighwayInsuranceInvalidSearchKey(valueName, searchProperties,
                                                               controlProperties.Select(x => x.Name).ToList());
                }

                // Add the search property, value and type
                this.SearchProperties.Add(foundField.GetValue(null).ToString(), saKeyVal[1], compareOperator);
            }
        }

        private static List<FieldInfo> GetAllPropertyNames()
        {
            List<FieldInfo> controlProperties = new List<FieldInfo>();

            Type nestedType = typeof (T);
            Type nestedPropertyNamesType = nestedType.GetNestedType("PropertyNames");

            while (nestedType != typeof (object))
            {
                if (nestedPropertyNamesType != null)
                {
                    controlProperties.AddRange(nestedPropertyNamesType.GetFields());
                }

                nestedType = nestedType.BaseType;
                nestedPropertyNamesType = nestedType.GetNestedType("PropertyNames");
            }
            return controlProperties;
        }

        public T1 Get<T1>() where T1 : IEnhancedControlBase
        {
            T1 control = EnhancedControlBaseFactory.Create<T1>();

            var baseControl = Activator.CreateInstance(control.GetBaseType(), new object[] { this.UnWrap() });

            control.Wrap(baseControl);

            return control;
        }

        /// <summary>
        /// Gets the Highway.Insurance UI control object from the descendants of this control using the search parameters are passed. 
        /// You don't have to create the object repository entry for this.
        /// </summary>
        /// <typeparam name="T">Pass the Highway.Insurance control you are looking for.</typeparam>
        /// <param name="searchParameters">In 'Key1=Value1;Key2=Value2' format. For example 'Id=firstname' 
        /// or use '~' for Contains such as 'Id~first'</param>
        /// <returns>Highway.Insurance _* control object</returns>
        public T1 Get<T1>(string searchParameters) where T1 : IEnhancedControlBase
        {
            T1 control = EnhancedControlBaseFactory.Create<T1>(searchParameters);

            var baseControl = Activator.CreateInstance(control.GetBaseType(), new object[] { this.UnWrap() });

            control.Wrap(baseControl);

            return control;
        }

        /// <summary>
        /// Get the Coded UI base type that is being wrapped by Highway.Insurance 
        /// </summary>
        /// <returns></returns>
        public Type GetBaseType()
        {
            return typeof(T);
        }

        /// <summary>
        /// Wraps the provided UITestControl in a Highway.Insurance object. 
        /// Fills the Coded UI control's search properties using values 
        /// set when the Highway.Insurance object was created.
        /// </summary>
        /// <param name="control"></param>
        public virtual void Wrap(object control, bool setSearchProperties = true)
        {
            this._control = control as T;
            if (setSearchProperties)
            {
                this._control.SearchProperties.AddRange(this.SearchProperties);
                this._control.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            }
        }

        /// <summary>
        /// UnWraps the Highway.Insurance controls to expose the underlying UITestControl.
        /// This helps when you want to use any methods/properties of the underlying UITestControl.
        /// Highway.Insurance controls are wrappers/abstractions which hides complexity. UnWrap() helps you break the abstraction.
        /// </summary>
        /// <returns>The underlying UITestControl instance. For example, returns HtmlEdit in case of Highway.Insurance.EnhancedHtmlEdit.</returns>
        public T UnWrap()
        {
            return this._control;
        }

        /// <summary>
        /// Wraps the provided UITestControl in a Highway.Insurance object.
        /// It does nothing with the control's search properties.
        /// </summary>
        /// <param name="control"></param>
        public void WrapReady(object control)
        {
            this._control = control as T;
        }

        /// <summary>
        /// Wraps the WaitForControlReady method for a UITestControl.
        /// </summary>
        public void WaitForControlReady()
        {
            this._control.WaitForControlReady();
        }

        /// <summary>
        /// Wraps WaitForControlReady and Click methods for a UITestControl.
        /// </summary>
        public void Click()
        {
            this._control.WaitForControlReady();
            int x = this._control.BoundingRectangle.X + this._control.BoundingRectangle.Width / 2;
            int y = this._control.BoundingRectangle.Y + this._control.BoundingRectangle.Height / 2;
            Mouse.Click(new Point(x, y));
        }

        public void Hover()
        {
            this._control.WaitForControlReady();
            Mouse.Hover(this._control);

        }

        /// <summary>
        /// Wraps WaitForControlReady and DoubleClick methods for a UITestControl.
        /// </summary>
        public void DoubleClick()
        {
            this._control.WaitForControlReady();
            Mouse.DoubleClick(this._control);
        }

        /// <summary>
        /// Wraps WaitForControlReady method and Enabled property for a UITestControl.
        /// </summary>
        public bool Enabled
        {
            get 
            {
                this._control.WaitForControlReady();
                return this._control.Enabled; 
            }
        }

        /// <summary>
        /// Wraps the Exists property for a UITestControl.
        /// </summary>
        public bool Exists
        {
            get 
            {
                if (this._control == null)
                {
                    return false;
                }

                return this._control.Exists; 
            }
        }

        /// <summary>
        /// Wraps WaitForControlReady and SetFocus methods for a UITestControl.
        /// </summary>
        public void SetFocus()
        {
            this._control.WaitForControlReady();
            this._control.SetFocus();
        }

        /// <summary>
        /// Wraps the adding of search properties for the UITestControl where
        /// the property expression is 'EqualTo'.
        /// </summary>
        /// <param name="sPropertyName"></param>
        /// <param name="sValue"></param>
        public void SetSearchProperty(string sPropertyName, string sValue)
        {
            this._control.SearchProperties.Add(sPropertyName, sValue, PropertyExpressionOperator.EqualTo);
        }

        /// <summary>
        /// Wraps the adding of search properties for the UITestControl where
        /// the property expression is 'Contains'.
        /// </summary>
        /// <param name="sPropertyName"></param>
        /// <param name="sValue"></param>
        public void SetSearchPropertyRegx(string sPropertyName, string sValue)
        {
            this._control.SearchProperties.Add(sPropertyName, sValue, PropertyExpressionOperator.Contains);
        }

        #region implementing parent, sibling etc methods as virtual

        public virtual IEnhancedControlBase Parent { get { return null; } }

        public virtual IEnhancedControlBase PreviousSibling { get { return null; } }

        public virtual IEnhancedControlBase NextSibling { get { return null; } }

        public virtual IEnhancedControlBase FirstChild { get { return null; } }

        public virtual List<IEnhancedControlBase> GetChildren() { return null; }

        #endregion
    }

    public enum SelectorType
    {
        Default = 0,
        JQuery
    }
}
