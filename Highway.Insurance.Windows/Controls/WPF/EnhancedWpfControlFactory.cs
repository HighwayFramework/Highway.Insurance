using System;
using Highway.Insurance.UI.Controls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Factory class for creating CUITe_Wpf* controls. Inherits from CUITe_ControlBaseFactory
    /// </summary>
    public class EnhancedWpfControlFactory : EnhancedControlBaseFactory
    {
        /// <summary>
        /// Create a CUITe_Wpf* control based on the type of provided WpfControl.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static IEnhancedControlBase Create(WpfControl control)
        {
            string CUITePrefix = ".CUITe_";
            string controlTypeName = control.GetType().Name;
            string CUITeNamespace = typeof(EnhancedWpfControlFactory).Namespace;

            // Get CUITe type based on WpfControl type and namespace
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
}