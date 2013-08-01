using System.Collections.Generic;
using Highway.Insurance.UI.Controls;

namespace Highway.Insurance.UI.Windows.Controls
{
    public interface IEnhancedWpfControl : IEnhancedControlBase
    {
        IEnhancedWpfControl Parent { get; }

        IEnhancedWpfControl PreviousSibling { get; }

        IEnhancedWpfControl NextSibling { get; }

        IEnhancedWpfControl FirstChild { get; }

        List<IEnhancedWpfControl> GetChildren();
    }
}