using System;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

// ReSharper disable CheckNamespace

namespace Highway.Insurance.UI.Windows.WinForms.Extensions
// ReSharper restore CheckNamespace
{
    public static class WinMenuExtensions
    {
        /// <summary>
        ///     Tells if a Menu is empty or not.
        /// </summary>
        /// <exception cref="ArgumentNullException">menu</exception>
        public static bool IsEmpty(this WinMenu menu)
        {
            if (menu == null) throw new ArgumentNullException("menu");

            return menu.Items.Count == 0;
        }
    }
}