using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

// ReSharper disable CheckNamespace

namespace Highway.Insurance.UI.Windows.WPF.Extensions
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