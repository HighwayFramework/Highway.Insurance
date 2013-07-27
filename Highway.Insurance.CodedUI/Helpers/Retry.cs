using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

// ReSharper disable CheckNamespace
namespace Highway.Insurance.UI.Helpers
// ReSharper restore CheckNamespace
{
    public static class Retry
    {
        public const int WindowWaitDefault = 30;
        public const int ElementWaitDefault = 10;
        private const int RetryIntervalInMs = 200;

        public static WpfWindow ForDefault(Func<WpfWindow> getMethod)
        {
            return For(getMethod, WindowWaitDefault);
        }

        public static T ForDefault<T>(Func<T> getMethod)
        {
            return For(getMethod, ElementWaitDefault);
        }

        public static WpfWindow ForDefault(Func<WpfWindow> getMethod, Predicate<WpfWindow> shouldRetry)
        {
            return For(getMethod, shouldRetry, WindowWaitDefault);
        }

        public static WinWindow ForDefault(Func<WinWindow> getMethod, Predicate<WinWindow> shouldRetry)
        {
            return For(getMethod, shouldRetry, WindowWaitDefault);
        }

        public static T ForDefault<T>(Func<T> getMethod, Predicate<T> shouldRetry)
        {
            return For(getMethod, shouldRetry, ElementWaitDefault);
        }

        /// <summary>
        ///     Retries until action does not throw an exception
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="retryForSeconds">The retry for seconds.</param>
        public static void For(Action action, int retryForSeconds)
        {
            DateTime startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).TotalSeconds < retryForSeconds)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception)
                {
                    Thread.Sleep(RetryIntervalInMs);
                }
            }

            action();
        }

        public static bool For(Func<bool> getMethod, int retryForSeconds)
        {
            return For(getMethod, g => !g, retryForSeconds);
        }

        public static T For<T>(Func<T> getMethod, int retryForSeconds)
        {
            //If T is a value type, by default we should retry if the value is default
            //Reference types will return false, so our predicate will always pass
            return For(getMethod, IsValueTypeAndDefault, retryForSeconds);
        }

        public static T For<T>(Func<T> getMethod, Predicate<T> shouldRetry, int retryForSeconds)
        {
            DateTime startTime = DateTime.Now;
            T element;
            while (DateTime.Now.Subtract(startTime).TotalSeconds < retryForSeconds)
            {
                try
                {
                    element = getMethod();
                }
                catch (Exception)
                {
                    Thread.Sleep(RetryIntervalInMs);
                    continue;
                }

                if (!typeof (T).IsValueType && element != null)
                    return element;

                //Making it safe for bool and value types and reference types
                if (typeof (T) == typeof (bool) && !shouldRetry(element))
                    return element;

                if (typeof (T) != typeof (bool) &&
                    !IsReferenceTypeAndIsNull(element) &&
                    !shouldRetry(element))
                {
                    return element;
                }

                Thread.Sleep(RetryIntervalInMs);
            }

            element = getMethod();
            return element;
        }

        private static bool IsReferenceTypeAndIsNull<T>(T element)
        {
            return (!(typeof (T).IsValueType) && ReferenceEquals(element, null));
        }

        private static bool IsValueTypeAndDefault<T>(T element)
        {
            return (typeof (T).IsValueType && element.Equals(default(T)));
        }
    }
}