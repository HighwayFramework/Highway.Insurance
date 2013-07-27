using System;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Factory class for creating CUITe_Win* controls. Inherits from CUITe_ControlBaseFactory
    /// </summary>
    public class EnhancedWinControlFactory : EnhancedControlBaseFactory
    {
        /// <summary>
        /// Create a CUITe_Win* control based on the type of provided WinControl.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static IEnhancedControlBase Create(WinControl control)
        {
            string CUITePrefix = ".CUITe_";
            string controlTypeName = control.GetType().Name;
            string CUITeNamespace = typeof(EnhancedWinControlFactory).Namespace;

            // Get CUITe type based on WinControl type and namespace
            Type CUITeType = Type.GetType(CUITeNamespace + CUITePrefix + controlTypeName);

            // The type will be null if it does not exist
            if (CUITeType == null)
            {
                throw new Exception(string.Format("Control Type '{0}' not supported", control.GetType().Name));
            }

            // Create CUITe control
            IEnhancedControlBase enhancedControl = (IEnhancedControlBase)Activator.CreateInstance(CUITeType);

            // Wrap WinControl
            enhancedControl.WrapReady(control);

            return enhancedControl;
        }
    }

    /// <summary>
    /// Base wrapper class for all CUITe_Win* controls, inherits from CUITe_ControlBase
    /// </summary>
    /// <typeparam name="T">The Coded UI WinControl type</typeparam>
    public class EnhancedWinControl<T> : EnhancedControlBase<T> where T : WinControl
    {
        public EnhancedWinControl() : base() { }
        public EnhancedWinControl(string searchParameters) : base(searchParameters) { }

        /// <summary>
        /// Gets the parent of the current CUITe control.
        /// </summary>
        public override IEnhancedControlBase Parent
        {
            get
            {
                this._control.WaitForControlReady();
                
                IEnhancedControlBase ret = null;
                
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
    }
}
