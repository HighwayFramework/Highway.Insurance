using System;
using Highway.Insurance.UI.Controls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.UI.Windows.Controls.WinForms
{
    /// <summary>
    /// Factory class for creating _Win* controls. Inherits from _ControlBaseFactory
    /// </summary>
    public class EnhancedWinControlFactory : EnhancedControlBaseFactory
    {
        /// <summary>
        /// Create a _Win* control based on the type of provided WinControl.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static IEnhancedWinControl Create(WinControl control)
        {
            string Prefix = ".Enhanced";
            string controlTypeName = control.GetType().Name;
            string Namespace = typeof(EnhancedWinControlFactory).Namespace;

            // Get  type based on WinControl type and namespace
            Type Type = Type.GetType(Namespace + Prefix + controlTypeName);

            // The type will be null if it does not exist
            if (Type == null)
            {
                throw new Exception(string.Format("Control Type '{0}' not supported", control.GetType().Name));
            }

            // Create  control
            var enhancedControl = (IEnhancedWinControl)Activator.CreateInstance(Type);

            // Wrap WinControl
            enhancedControl.WrapReady(control);

            return enhancedControl;
        }
    }
}