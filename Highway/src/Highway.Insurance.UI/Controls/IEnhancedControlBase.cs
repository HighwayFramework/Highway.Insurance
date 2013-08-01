using System;
using System.Collections.Generic;

namespace Highway.Insurance.UI.Controls
{
    public interface IEnhancedControlBase
    {
        Type GetBaseType();

        void Wrap(object control, bool setSearchProperties = true);

        void WrapReady(object control);

        void WaitForControlReady();

        void Click();

        void DoubleClick();

        bool Enabled
        {
            get;
        }   

        bool Exists
        {
            get;
        }

        void SetFocus();

        void SetSearchProperty(string sPropertyName, string sValue);

        void SetSearchPropertyRegx(string sPropertyName, string sValue);

        void Hover();

        /// <summary>
        /// Wraps WaitForControlReady and Click methods for a UITestControl.
        /// </summary>
        void Click(ClickPosition position);
    }
}