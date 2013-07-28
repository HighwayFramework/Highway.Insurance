using System;
using Highway.Insurance.UI.Controls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Factory class for creating _Wpf* controls. Inherits from _ControlBaseFactory
    /// </summary>
    public class EnhancedWpfControlFactory : EnhancedControlBaseFactory
    {
        /// <summary>
        /// Create a _Wpf* control based on the type of provided WpfControl.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static IEnhancedControlBase Create(WpfControl control)
        {
            string Prefix = ".Enhanced";
            string controlTypeName = control.GetType().Name;
            string Namespace = typeof(EnhancedWpfControlFactory).Namespace;

            // Get  type based on WpfControl type and namespace
            Type Type = Type.GetType(Namespace + Prefix + controlTypeName);

            // The type will be null if it does not exist
            if (Type == null)
            {
                throw new Exception(string.Format("Control Type '{0}' not supported", control.GetType().Name));
            }

            // Create  control
            IEnhancedControlBase enhancedControl = (IEnhancedControlBase)Activator.CreateInstance(Type);

            // Wrap WinControl
            enhancedControl.WrapReady(control);

            return enhancedControl;
        }
    }
}