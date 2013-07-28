using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfCalendar
    /// </summary>
    public class EnhancedWpfCalendar : EnhancedWpfControl<WpfCalendar>
    {
        public EnhancedWpfCalendar() : base() { }
        public EnhancedWpfCalendar(string searchParameters) : base(searchParameters) { }

        public DateTime[] SelectedDates
        {
            get { return this.UnWrap().SelectedDates; }
            set { this.UnWrap().SelectedDates = value; }
        }

        public string SelectedDatesAsString
        {
            get { return this.UnWrap().SelectedDatesAsString; }
            set { this.UnWrap().SelectedDatesAsString = value; }
        }
    }
}