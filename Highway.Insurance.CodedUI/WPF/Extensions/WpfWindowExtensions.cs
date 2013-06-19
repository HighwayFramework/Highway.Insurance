using System.Windows.Input;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WpfControls
// ReSharper restore CheckNamespace
{
    public static class WpfWindowExtensions
    {
        public static WpfWindow GetWindow(this WpfWindow parent, string windowTitle, bool exactMatch = false)
        {
            PropertyExpressionOperator expressionOperator = exactMatch
                                                                ? PropertyExpressionOperator.EqualTo
                                                                : PropertyExpressionOperator.Contains;
            var modalWindow = new WpfWindow
                {
                    SearchProperties =
                        {
                            {UITestControl.PropertyNames.Name, windowTitle, expressionOperator}
                        }
                };

            modalWindow.Find();
            return modalWindow;
        }

        public static WpfWindow AccessKeyPress(this WpfWindow currentScreen, string accessKey)
        {
            Keyboard.PressModifierKeys(ModifierKeys.Alt);
            Keyboard.SendKeys(accessKey);
            Keyboard.ReleaseModifierKeys(ModifierKeys.Alt);

            return currentScreen;
        }
    }
}