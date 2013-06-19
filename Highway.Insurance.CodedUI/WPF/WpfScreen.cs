using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.CodedUI.WPF
{
    public class WpfScreen
    {
        public WpfScreen(ApplicationBase<WpfWindow> application, WpfWindow window)
        {
            Application = application;
            Window = window;
        }

        public ApplicationBase<WpfWindow> Application { get; set; }
        public WpfWindow Window { get; set; }
    }
}