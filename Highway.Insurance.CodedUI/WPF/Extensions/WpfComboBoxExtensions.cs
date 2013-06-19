using System;
using System.Linq;

// ReSharper disable CheckNamespace

namespace Microsoft.VisualStudio.TestTools.UITesting.WpfControls
// ReSharper restore CheckNamespace
{
    public static class WpfComboBoxExtensions
    {
        public static void Select(this WpfComboBox listControl, Predicate<WpfListItem> shouldSelectItem)
        {
            listControl.WaitForControlEnabled();

            listControl.SelectedItem = listControl.Items.Cast<WpfListItem>().First(i => shouldSelectItem(i)).DisplayText;
        }
    }
}