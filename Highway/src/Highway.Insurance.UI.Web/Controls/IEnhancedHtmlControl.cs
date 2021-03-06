﻿using System.Collections.Generic;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls
{
    public interface IEnhancedHtmlControl : IEnhancedControlBase
    {
        string InnerText
        {
            get;
        }

        bool IsVisible();
        Dictionary<string, string> Data();

        IEnhancedHtmlControl Parent { get; }

        IEnhancedHtmlControl PreviousSibling { get; }

        IEnhancedHtmlControl NextSibling { get; }

        IEnhancedHtmlControl FirstChild { get; }

        List<IEnhancedHtmlControl> GetChildren();
        bool CurrentlyExists();
    }
}