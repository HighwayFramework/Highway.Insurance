using System.Collections.Generic;

namespace Highway.Insurance.UI.Windows.Controls
{
    public interface IEnhancedWpfControl
    {
        IEnhancedWpfControl Parent { get; }

        IEnhancedWpfControl PreviousSibling { get; }

        IEnhancedWpfControl NextSibling { get; }

        IEnhancedWpfControl FirstChild { get; }

        List<IEnhancedWpfControl> GetChildren();
    }
}