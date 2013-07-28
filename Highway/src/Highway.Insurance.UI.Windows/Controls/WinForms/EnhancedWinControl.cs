using System;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Exceptions;
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
        public static IEnhancedControlBase Create(WinControl control)
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
            IEnhancedControlBase enhancedControl = (IEnhancedControlBase)Activator.CreateInstance(Type);

            // Wrap WinControl
            enhancedControl.WrapReady(control);

            return enhancedControl;
        }
    }

    /// <summary>
    /// Base wrapper class for all _Win* controls, inherits from _ControlBase
    /// </summary>
    /// <typeparam name="T">The Coded UI WinControl type</typeparam>
    public class EnhancedWinControl<T> : EnhancedControlBase<T> where T : WinControl
    {
        public EnhancedWinControl() : base() { }
        public EnhancedWinControl(string searchParameters) : base(searchParameters) { }

        /// <summary>
        /// Gets the parent of the current  control.
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
