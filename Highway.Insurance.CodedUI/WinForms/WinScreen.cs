using Microsoft.VisualStudio.TestTools.UITesting.WinControls;

namespace Highway.Insurance.CodedUI.WinForms
{
    public class WpfScreen
    {
        public WpfScreen(ApplicationBase<WinWindow> application, WinWindow window)
        {
            Application = application;
            Window = window;
        }

        public ApplicationBase<WinWindow> Application { get; set; }
        public WinWindow Window { get; set; }
    }
}