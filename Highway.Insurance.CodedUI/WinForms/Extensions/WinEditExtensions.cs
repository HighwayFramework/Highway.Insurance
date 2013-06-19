using System;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Automation.Text;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WinControls
// ReSharper restore CheckNamespace
{
    public static class WinEditExtensions
    {
        public static void Enter(this WinEdit control, string text)
        {
            Keyboard.SendKeys(control, text);
        }

        /// <summary>
        ///     Tells you if a WpfEdit is on read only mode.
        /// </summary>
        /// <param name="control">The target win edit automation element.</param>
        /// <returns>True if the wpfEdit is readOnly, False otherwise.</returns>
        /// <exception cref="ArgumentNullException">richText</exception>
        /// <exception cref="InvalidOperationException">Cannot retrieve the info from the control</exception>
        public static bool IsReadOnly(this WinEdit richText)
        {
            if (richText == null) throw new ArgumentNullException("richText");
            AutomationElement element = WinControlExtensions.GetAutomationElement(richText);
            richText.SetFocus();
            var pattern = element.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (pattern == null) throw new InvalidOperationException("Cannot retrieve the info from the control");
            //pattern.DocumentRange.Select();

            TextPatternRange[] selection = pattern.GetSelection();
            if (selection.Any())
            {
                object attValue = selection[0].GetAttributeValue(TextPattern.IsReadOnlyAttribute);
                if (attValue == null) throw new InvalidOperationException("Cannot retrieve the info from the control");
                //pattern.DocumentRange.RemoveFromSelection();
                return bool.Parse(attValue.ToString());
            }

            throw new InvalidOperationException("Cannot retrieve the info from the control");
        }
    }
}