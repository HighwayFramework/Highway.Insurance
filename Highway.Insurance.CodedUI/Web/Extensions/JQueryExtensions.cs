using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Highway.Insurance.CodedUI.Web.Extensions
{
    public static class JQueryExtensions
    {
        public static IEnumerable<T> FindControlsBySelector<T>(this BrowserWindow window, string selector)
        {
            var controlsBySelector = (IEnumerable<T>)window.ExecuteScript(string.Format("return $('{0}')", selector));
            return controlsBySelector;
        }

        public static T FindControlBySelector<T>(this BrowserWindow window, string selector)
        {
            var controlBySelector = (T) window.ExecuteScript(string.Format("return $('{0}')[0]", selector));
            return controlBySelector;
        }

        public static string PrepareForSelector(this string input)
        {
            return input.Replace(' ', '-').Replace('.', '-');
        }
    }
}