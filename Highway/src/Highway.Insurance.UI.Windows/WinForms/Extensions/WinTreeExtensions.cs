using System;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

// ReSharper disable CheckNamespace

namespace Highway.Insurance.UI.Windows.WinForms.Extensions
// ReSharper restore CheckNamespace
{
    public static class WinTreeExtensions
    {
        /// <summary>
        ///     Tells if a TreeView is empty or not.
        /// </summary>
        /// <exception cref="ArgumentNullException">tree</exception>
        public static bool IsEmpty(this WinTree tree)
        {
            if (tree == null) throw new ArgumentNullException("tree");

            return tree.Nodes.Count == 0;
        }
    }
}