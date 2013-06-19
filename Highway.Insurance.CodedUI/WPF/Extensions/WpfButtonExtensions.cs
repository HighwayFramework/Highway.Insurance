 // ReSharper disable CheckNamespace
namespace Microsoft.VisualStudio.TestTools.UITesting.WpfControls
// ReSharper restore CheckNamespace
{
    public static class WpfButtonExtensions
    {
        public static void Click(this WpfButton button)
        {
            Mouse.Click(button);
        }
    }
}