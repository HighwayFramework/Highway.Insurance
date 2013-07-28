using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Highway.Insurance.UI.Windows.Controls.WPF
{
    /// <summary>
    /// Wrapper class for WpfImage
    /// </summary>
    public class EnhancedWpfImage : EnhancedWpfControl<WpfImage>
    {
        public EnhancedWpfImage() : base() { }
        public EnhancedWpfImage(string searchParameters) : base(searchParameters) { }

        public string Alt
        {
            get { return this.UnWrap().Alt; }
        }
    }
}