using System.Collections.Generic;
using Highway.Insurance.UI.Controls;

namespace Highway.Insurance.UI.Windows.Controls
{
    public interface IEnhancedWinControl : IEnhancedControlBase
    {
        IEnhancedWinControl Parent { get; }

        IEnhancedWinControl PreviousSibling { get; }

        IEnhancedWinControl NextSibling { get; }

        IEnhancedWinControl FirstChild { get; }

        List<IEnhancedWinControl> GetChildren();
 
    }
}