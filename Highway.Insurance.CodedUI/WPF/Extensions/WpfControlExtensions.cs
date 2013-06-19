using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WpfControls
// ReSharper restore CheckNamespace
{
    public static class WpfControlExtensions
    {
        public static T GetByAutomationId<T>(this WpfControl container, string automationId, string technology = "MSAA")
            where T : WpfControl, new()
        {
            container.WaitForControlReady();
            var foo = new T
                {
                    Container = container,
                    SearchProperties =
                        {
                            {WpfControl.PropertyNames.AutomationId, automationId}
                        },
                    TechnologyName = technology
                };

            foo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            foo.Find();
            return foo;
        }

        public static T GetByName<T>(this WpfControl container, string name, string technology = "MSAA")
            where T : WpfControl, new()
        {
            container.WaitForControlReady();
            var foo = new T
                {
                    Container = container,
                    SearchProperties =
                        {
                            {UITestControl.PropertyNames.Name, name}
                        },
                    TechnologyName = technology
                };

            foo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            foo.Find();
            return foo;
        }

        public static T Get<T>(this WpfControl container, Func<PropertyExpressionCollection> searchProperties,
                               string technology = "MSAA")
            where T : WpfControl, new()
        {
            container.WaitForControlReady();
            var foo = new T
                {
                    Container = container,
                    TechnologyName = technology
                };
            foo.SearchProperties.AddRange(searchProperties());

            foo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            foo.Find();
            return foo;
        }

        public static IEnumerable<T> GetMultipleByAutomationId<T>(this WpfControl container, string automationId,
                                                                  string technology = "MSAA")
            where T : WpfControl, new()
        {
            container.WaitForControlReady();
            var foo = new T
                {
                    Container = container,
                    SearchProperties =
                        {
                            {WpfControl.PropertyNames.AutomationId, automationId}
                        },
                    TechnologyName = technology
                };

            foo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            return foo.FindMatchingControls().Cast<T>();
        }

        public static IEnumerable<T> GetMultipleByName<T>(this WpfControl container, string name,
                                                          string technology = "MSAA")
            where T : WpfControl, new()
        {
            container.WaitForControlReady();
            var foo = new T
                {
                    Container = container,
                    SearchProperties =
                        {
                            {UITestControl.PropertyNames.Name, name}
                        },
                    TechnologyName = technology
                };

            foo.SearchConfigurations.Add(SearchConfiguration.AlwaysSearch);
            return foo.FindMatchingControls().Cast<T>();
        }

        /// <summary>
        ///     Try to select the control using the SelectionItemPattern
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <returns>True if the operation succeed, false otherwise.</returns>
        public static bool TrySelect(this WpfControl control)
        {
            try
            {
                AutomationElement automationElement = GetAutomationElement(control);
                if (automationElement == null) return false;

                object objectPattern;
                if (!automationElement.TryGetCurrentPattern(SelectionItemPattern.Pattern, out objectPattern))
                    return false;
                var pattern = objectPattern as SelectionItemPattern;

                if (pattern != null) pattern.Select();
                return true;
            }
            catch
            {
            }

            return false;
        }

        internal static AutomationElement GetAutomationElement(WpfControl control)
        {
            var automationElement = control.NativeElement as AutomationElement;
            return automationElement;
        }

        /// <summary>
        ///     Try to expand the control using the ExpandCollapsePattern
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <returns>True if the operation succeed, false otherwise.</returns>
        public static bool TryExpand(this WpfControl control)
        {
            try
            {
                var automationElement = control.NativeElement as AutomationElement;
                if (automationElement == null) return false;

                object objectPattern;
                if (!automationElement.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out objectPattern))
                    return false;
                var pattern = objectPattern as ExpandCollapsePattern;

                if (pattern != null
                    && pattern.Current.ExpandCollapseState != ExpandCollapseState.Expanded
                    && pattern.Current.ExpandCollapseState != ExpandCollapseState.LeafNode
                    ) pattern.Expand();

                return true;
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        ///     Try to collapse the control using the ExpandCollapsePattern
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <returns>True if the operation succeed, false otherwise.</returns>
        public static bool TryCollapse(this WpfControl control)
        {
            try
            {
                var automationElement = control.NativeElement as AutomationElement;
                if (automationElement == null) return false;

                object objectPattern;
                if (!automationElement.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out objectPattern))
                    return false;
                var pattern = objectPattern as ExpandCollapsePattern;

                if (pattern != null
                    && pattern.Current.ExpandCollapseState != ExpandCollapseState.Collapsed
                    && pattern.Current.ExpandCollapseState != ExpandCollapseState.LeafNode) pattern.Collapse();

                return true;
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        ///     Get all the children of a control of a given type.
        ///     It can returns only direct children or all of them.
        /// </summary>
        /// <typeparam name="T">The aimed type of child.</typeparam>
        /// <param name="onlyDirectChildren">Do you want only direct children ?</param>
        /// <param name="control">The target control.</param>
        /// <returns>The children of the aimed type. An empty list if there is none.</returns>
        public static List<T> GetChildren<T>(this WpfControl control, bool onlyDirectChildren = true)
            where T : WpfControl
        {
            UITestControlCollection children = control.GetChildren();
            var controls = new List<T>();
            GetChildren(children, controls, onlyDirectChildren);
            return controls;
        }

        private static void GetChildren<T>(
            IEnumerable<UITestControl> children, List<T> ctrls, bool onlyDirectChildren = true)
            where T : WpfControl
        {
            IEnumerable<WpfControl> casted = children.Cast<WpfControl>();

            foreach (WpfControl child in casted)
            {
                if (!onlyDirectChildren) GetChildren(child.GetChildren(), ctrls);

                var castedChild = child as T;
                if (castedChild == null) continue;

                ctrls.Add(castedChild);
            }
        }

        /// <summary>
        ///     Try to call the invoke pattern on the target control.
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <returns>True if the operation succeed, false otherwise.</returns>
        public static bool TryInvoke(this WpfControl control)
        {
            try
            {
                var automationElement = control.NativeElement as AutomationElement;
                if (automationElement == null) return false;

                object objectPattern;
                if (!automationElement.TryGetCurrentPattern(InvokePattern.Pattern, out objectPattern))
                    return false;
                var pattern = objectPattern as InvokePattern;

                if (pattern != null) pattern.Invoke();

                return true;
            }
            catch
            {
            }
            return false;
        }


        /// <summary>
        ///     Try to set the text on a control.
        ///     It uses the value pattern and if not available, simulate key press.
        ///     More info at this acdress : http://msdn.microsoft.com/en-us/library/ms750582.aspx
        /// </summary>
        public static bool TrySetText(this WpfControl control, string valueToSet)
        {
            //TextPattern and ValuePattern cannnot be used on the same control
            // NOTE: Elements that support TextPattern 
            //       do not support ValuePattern and TextPattern
            //       does not support setting the text of 
            //       multi-line edit or document controls.
            //       For this reason, text input must be simulated
            //       using one of the following methods.
            //       
            if (!control.TrySetValue(valueToSet))
            {
                control.SetFocus();
                Keyboard.SendKeys("^{HOME}"); // Move to start of control
                Keyboard.SendKeys("^+{END}"); // Select everything
                Keyboard.SendKeys("{DEL}"); // Delete selection
                Keyboard.SendKeys(valueToSet);
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Try to set the value to the control using the ValuePattern.
        /// </summary>
        /// <param name="valueToSet"></param>
        /// <param name="control">The target control.</param>
        /// <returns>True if the operation succeed, false otherwise.</returns>
        public static bool TrySetValue(this WpfControl control, string valueToSet)
        {
            try
            {
                var automationElement = control.NativeElement as AutomationElement;
                if (automationElement == null) return false;

                object objectPattern;
                if (!automationElement.TryGetCurrentPattern(ValuePattern.Pattern, out objectPattern))
                    return false;

                var pattern = objectPattern as ValuePattern;

                if (pattern != null)
                    pattern.SetValue(valueToSet);

                return true;
            }
            catch
            {
            }
            return false;
        }

        /// <summary>
        ///     Returns the control's direct children automation ids.
        /// </summary>
        /// <param name="control"></param>
        /// <returns>A list of all automation id. It may be empty.</returns>
        /// <exception cref="InvalidOperationException">Cannot retrieve the automation element.</exception>
        public static List<string> GetChildrenAutomationIds(this WpfControl control)
        {
            UITestControlCollection collection = control.GetChildren();
            List<string> ids = collection.Select
                (c =>
                    {
                        var automationElement = c.NativeElement as AutomationElement;
                        if (automationElement == null)
                            throw new InvalidOperationException("Cannot retrieve the automation element.");

                        return automationElement.Current.AutomationId;
                    }).ToList();
            return ids;
        }


        /// <summary>
        ///     Dump to the output all the search properties of a Wpf control.
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <param name="traceInsteadOfDebug">Dump to the trace instead of the debug output.</param>
        /// <exception cref="ArgumentNullException">control</exception>
        public static void DumpSearchProperties(this WpfControl control, bool traceInsteadOfDebug = false)
        {
            if (control == null) throw new ArgumentNullException("control");
            DumpPropertyExpressions(control, traceInsteadOfDebug, control.SearchProperties);
        }


        /// <summary>
        ///     Dump to the output all the filter properties of a Wpf control.
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <param name="traceInsteadOfDebug">Dump to the trace instead of the debug output.</param>
        /// <exception cref="ArgumentNullException">control</exception>
        public static void DumpFilterProperties(this WpfControl control, bool traceInsteadOfDebug = false)
        {
            if (control == null) throw new ArgumentNullException("control");
            DumpPropertyExpressions(control, traceInsteadOfDebug, control.FilterProperties);
        }


        private static void DumpPropertyExpressions(
            WpfControl control, bool traceInsteadOfDebug, IEnumerable<PropertyExpression> propertyExpressionCollection)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("SearchProperties for {0}{1}", control, Environment.NewLine);

            foreach (PropertyExpression sp in propertyExpressionCollection)
            {
                sb.AppendFormat
                    ("  -> {0} {1} {2}{3}",
                     sp.PropertyName,
                     sp.PropertyOperator,
                     sp.PropertyValue,
                     Environment.NewLine);
            }

            if (traceInsteadOfDebug) Trace.WriteLine(sb.ToString());
            else Debug.WriteLine(sb.ToString());
        }

        /// <summary>
        ///     Dump to the output all the Search Configurations of a Wpf control.
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <param name="traceInsteadOfDebug">Dump to the trace instead of the debug output.</param>
        /// <exception cref="ArgumentNullException">control</exception>
        public static void DumpSearchConfigurations(this WpfControl control, bool traceInsteadOfDebug = false)
        {
            if (control == null) throw new ArgumentNullException("control");
            var sb = new StringBuilder();

            sb.AppendFormat("SearchConfigurations for {0}{1}", control, Environment.NewLine);
            foreach (string sp in control.SearchConfigurations)
            {
                sb.AppendFormat("  -> {0}{1}", sp, Environment.NewLine);
            }

            if (traceInsteadOfDebug) Trace.WriteLine(sb.ToString());
            else Debug.WriteLine(sb.ToString());
        }


        /// <summary>
        ///     Dump to the output all the supported properties of a Wpf control.
        /// </summary>
        /// <param name="control">The target control.</param>
        /// <param name="traceInsteadOfDebug">Dump to the trace instead of the debug output.</param>
        /// <exception cref="ArgumentNullException">control</exception>
        public static void DumpSupportedProperties(this WpfControl control, bool traceInsteadOfDebug = false)
        {
            if (control == null) throw new ArgumentNullException("control");
            var sb = new StringBuilder();
            var element = control.NativeElement as AutomationElement;

            sb.AppendFormat("SupportedProperties for {0}{1}", control, Environment.NewLine);
            if (element != null)
            {
                foreach (AutomationProperty sp in element.GetSupportedProperties())
                {
                    sb.AppendFormat
                        ("  -> {0}: {1}{2}",
                         sp.ProgrammaticName,
                         element.GetCurrentPropertyValue(sp),
                         Environment.NewLine);
                }
            }

            if (traceInsteadOfDebug) Trace.WriteLine(sb.ToString());
            else Debug.WriteLine(sb.ToString());
        }
    }
}