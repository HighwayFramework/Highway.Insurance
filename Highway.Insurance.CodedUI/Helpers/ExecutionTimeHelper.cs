 // ReSharper disable CheckNamespace

using System;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace Microsoft.VisualStudio.TestTools.UITesting
// ReSharper restore CheckNamespace
{
    public static class ExecutionTimeHelper
    {
         public static void RunImmediate(Action action)
         {
             Playback.PlaybackSettings.ShouldSearchFailFast = true;
             action();
             Playback.PlaybackSettings.ShouldSearchFailFast = false;
         }
    }
}