using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfDatePicker
    /// </summary>
    public class EnhancedWpfDatePicker : EnhancedWpfControl<WpfDatePicker>
    {
        public EnhancedWpfDatePicker() : base() { }
        public EnhancedWpfDatePicker(string searchParameters) : base(searchParameters) { }

        public EnhancedWpfCalendar Calendar
        {
            get
            {
                EnhancedWpfCalendar calendar = new EnhancedWpfCalendar();
                calendar.WrapReady(this.UnWrap().Calendar);
                return calendar;
            }
        }

        public DateTime Date
        {
            get { return this.UnWrap().Date; }
            set { this.UnWrap().Date = value; }
        }

        public string DateAsString
        {
            get { return this.UnWrap().DateAsString; }
            set { this.UnWrap().DateAsString = value; }
        }

        public bool ShowCalendar
        {
            get { return this.UnWrap().ShowCalendar; }
            set { this.UnWrap().ShowCalendar = value; }
        }
    }
}