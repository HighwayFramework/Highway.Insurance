// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WinControls
// ReSharper restore CheckNamespace
{
    public static class WinButtonExtensions
    {
        public static void Click(this WinButton button)
        {
            Mouse.Click(button);
        }
    }
}