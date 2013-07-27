using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

// ReSharper disable CheckNamespace

namespace Highway.Insurance.UI.Windows.WinForms.Extensions
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