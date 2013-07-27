using System;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

// ReSharper disable CheckNamespace

namespace Highway.Insurance.UI.Windows.WinForms.Extensions
// ReSharper restore CheckNamespace
{
    public static class WinListExtensions
    {
        /// <summary>
        ///     Tells if a List is empty or not.
        /// </summary>
        /// <exception cref="ArgumentNullException">list</exception>
        public static bool IsEmpty(this WinList list)
        {
            if (list == null) throw new ArgumentNullException("list");

            return list.Items.Count == 0;
        }
    }
}