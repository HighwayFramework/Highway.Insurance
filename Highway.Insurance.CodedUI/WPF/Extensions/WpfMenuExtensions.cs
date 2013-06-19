using System;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WpfControls
// ReSharper restore CheckNamespace
{
    public static class WpfMenuExtensions
    {
        /// <summary>
        ///     Tells if a Menu is empty or not.
        /// </summary>
        public static bool IsEmpty(this WpfMenu menu)
        {
            if (menu == null) throw new ArgumentNullException("menu");

            return menu.Items.Count == 0;
        }
    }
}