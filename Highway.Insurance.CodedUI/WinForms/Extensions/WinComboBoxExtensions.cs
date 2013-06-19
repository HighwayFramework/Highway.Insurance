using System;
using System.Linq;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WinControls
// ReSharper restore CheckNamespace
{
    public static class WinComboBoxExtensions
    {
        public static void Select(this WinComboBox listControl, Predicate<WinListItem> shouldSelectItem)
        {
            listControl.WaitForControlEnabled();

            listControl.SelectedItem = listControl.Items.Cast<WinListItem>().First(i => shouldSelectItem(i)).DisplayText;
        }
    }
}