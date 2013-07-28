using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Base wrapper class for all Highway.Insurance _Wpf* controls, inherits from Highway.Insurance _ControlBase
    /// </summary>
    /// <typeparam name="T">The Coded UI WpfControl type</typeparam>
    public class EnhancedWpfControl<T> : EnhancedControlBase<T> where T : WpfControl
    {
        public EnhancedWpfControl() : base() { }
        public EnhancedWpfControl(string searchParameters) : base(searchParameters) { }

        /// <summary>
        /// Gets the parent of the current Highway.Insurance control.
        /// </summary>
        public override IEnhancedControlBase Parent
        {
            get
            {
                this._control.WaitForControlReady();
                
                IEnhancedControlBase ret = null;
                
                try
                {
                    ret = EnhancedWpfControlFactory.Create((WpfControl)this._control.GetParent());
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new HighwayInsuranceInvalidTraversal(string.Format("({0}).Parent", this._control.GetType().Name));
                }
                return ret;
            }
        }


        /// <summary>
        /// Wrap AcceleratorKey property common to all WPF controls
        /// </summary>
        public string AcceleratorKey
        {
            get { return this.UnWrap().AcceleratorKey; }
        }

        /// <summary>
        /// Wrap AccessKey property common to all WPF controls
        /// </summary>
        public string AccessKey
        {
            get { return this.UnWrap().AccessKey; }
        }

        /// <summary>
        /// Wrap AutomationId property common to all WPF controls
        /// </summary>
        public string AutomationId
        {
            get { return this.UnWrap().AutomationId; }
        }

        /// <summary>
        /// Wrap Font property common to all WPF controls
        /// </summary>
        public string Font
        {
            get { return this.UnWrap().Font; }
        }

        /// <summary>
        /// Wrap HelpText property common to all WPF controls
        /// </summary>
        public string HelpText
        {
            get { return this.UnWrap().HelpText; }
        }

        /// <summary>
        /// Wrap LabeledBy property common to all WPF controls
        /// </summary>
        public string LabeledBy
        {
            get { return this.UnWrap().LabeledBy; }
        }
    }
}
