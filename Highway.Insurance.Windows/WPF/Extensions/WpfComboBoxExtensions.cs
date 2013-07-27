using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

// ReSharper disable CheckNamespace

namespace Highway.Insurance.UI.Windows.WPF.Extensions
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