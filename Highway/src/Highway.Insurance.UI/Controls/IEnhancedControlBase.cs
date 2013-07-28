using System;
using System.Collections.Generic;

namespace Highway.Insurance.UI.Controls
{
    public interface IEnhancedControlBase
    {
        Type GetBaseType();

        void Wrap(object control);

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

        IEnhancedControlBase Parent { get; }

        IEnhancedControlBase PreviousSibling { get; }

        IEnhancedControlBase NextSibling { get; }

        IEnhancedControlBase FirstChild { get; }

        List<IEnhancedControlBase> GetChildren();
    }
}