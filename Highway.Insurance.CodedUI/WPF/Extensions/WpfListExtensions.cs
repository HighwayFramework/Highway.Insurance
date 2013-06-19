using System;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WpfControls
// ReSharper restore CheckNamespace
{
    public static class WpfListExtensions
    {
        /// <summary>
        ///     Tells if a List is empty or not.
        /// </summary>
        public static bool IsEmpty(this WpfList list)
        {
            if (list == null) throw new ArgumentNullException("list");

            return list.Items.Count == 0;
        }
    }
}