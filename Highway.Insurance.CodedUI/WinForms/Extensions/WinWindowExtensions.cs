using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WpfControls
// ReSharper restore CheckNamespace
{
    public static class WinWindowExtensions
    {
        public static WinWindow GetWindow(this WinWindow parent, string windowTitle, bool exactMatch = false)
        {
            PropertyExpressionOperator expressionOperator = exactMatch
                                                                ? PropertyExpressionOperator.EqualTo
                                                                : PropertyExpressionOperator.Contains;
            var modalWindow = new WinWindow
                {
                    SearchProperties =
                        {
                            new PropertyExpression(UITestControl.PropertyNames.Name, windowTitle, expressionOperator)
                        }
                };

            modalWindow.Find();
            return modalWindow;
        }

        public static WinWindow AccessKeyPress(this WinWindow currentScreen, string accessKey)
        {
            Keyboard.PressModifierKeys(ModifierKeys.Alt);
            Keyboard.SendKeys(accessKey);
            Keyboard.ReleaseModifierKeys(ModifierKeys.Alt);

            return currentScreen;
        }
    }
}