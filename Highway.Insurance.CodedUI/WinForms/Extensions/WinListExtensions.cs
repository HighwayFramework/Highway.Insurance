using System;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WinControls
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