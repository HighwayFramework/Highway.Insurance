using System;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WpfControls
// ReSharper restore CheckNamespace
{
    public static class WpfTreeExtensions
    {
        /// <summary>
        ///     Tells if a TreeView is empty or not.
        /// </summary>
        public static bool IsEmpty(this WpfTree tree)
        {
            if (tree == null) throw new ArgumentNullException("tree");

            return tree.Nodes.Count == 0;
        }
    }
}