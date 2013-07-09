// ReSharper disable CheckNamespace

using System;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace Microsoft.VisualStudio.TestTools.UITesting
// ReSharper restore CheckNamespace
{
    public abstract class ExecutionTimeHelper
    {
        public static void RunImmediate(Action action)
        {
            Playback.PlaybackSettings.ShouldSearchFailFast = true;
            action();
            Playback.PlaybackSettings.ShouldSearchFailFast = false;
        }

        public static Tuple<bool, T> TryFind<T>(Func<T> action, int timeout) where T : class
        {
            var originalSearch = Playback.PlaybackSettings.SearchTimeout;
            Playback.PlaybackSettings.SearchTimeout = timeout;
            var item = action();
            Playback.PlaybackSettings.SearchTimeout = originalSearch;
            return new Tuple<bool, T>(item == null, item);
        }

        public static void DisableWait()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
        }

        public static void UIWait()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.UIThreadOnly;
        }

        public static void AllThreadWait()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;
        }
    }
}