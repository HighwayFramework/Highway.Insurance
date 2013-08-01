using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Highway.Insurance.UI.Web.Controls;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web
{
    public static class JQueryExtensions
    {
        public static IEnumerable<T> FindControlsBySelector<T>(this BrowserWindow window, string selector) where T : HtmlControl
        {
            var controlsBySelector = (IEnumerable<T>)window.ExecuteScript(string.Format("return $('{0}')", selector));
            return controlsBySelector;
        }

        public static T FindControlBySelector<T>(this BrowserWindow window, string selector) where T : HtmlControl
        {
            object obj = window.ExecuteScript(string.Format("return $('{0}')[0]", selector));
            var list = obj as List<object>;
            return (list != null ? list.OfType<T>().First() : (T) obj);
        }

        public static object FindControlBySelector(this BrowserWindow window,Type htmlType, string selector)
        {
            var controlBySelector = Convert.ChangeType(window.ExecuteScript(string.Format("return $('{0}')[0]", selector)),htmlType);
            return controlBySelector;
        }

        public static IEnumerable<object> FindControlsBySelector(this BrowserWindow window, Type htmlType, string selector)
        {
            var controls = (IEnumerable) window.ExecuteScript(string.Format("return $('{0}')[0]", selector));
            return controls.Cast<object>().Select(control => Convert.ChangeType(control, htmlType));
        }

        public static string PrepareForSelector(this string input)
        {
            return input.Replace(' ', '-').Replace('.', '-');
        }
    }
}