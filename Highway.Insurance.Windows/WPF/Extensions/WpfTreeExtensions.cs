using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

// ReSharper disable CheckNamespace

namespace Highway.Insurance.UI.Windows.WPF.Extensions
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