using System.Collections.Generic;

namespace Highway.Insurance.UI.Windows.Controls
{
    public interface IEnhancedWinControl
    {
        IEnhancedWinControl Parent { get; }

        IEnhancedWinControl PreviousSibling { get; }

        IEnhancedWinControl NextSibling { get; }

        IEnhancedWinControl FirstChild { get; }

        List<IEnhancedWinControl> GetChildren();
 
    }
}