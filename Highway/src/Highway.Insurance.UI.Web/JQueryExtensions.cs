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
            object obj = window.ExecuteScript(string.Format("return $('{0}')", selector));
            var list = obj as List<object>;

            if (list != null)
            {
                if (list.OfType<T>().FirstOrDefault() == null)
                    throw new InvalidCastException(string.Format("Type of {0} not expected Type of {1}",
                        obj.GetType().Name, typeof (T).Name));
                return list.OfType<T>().First();
            }
            else
            {
                var controlBySelector = (T) obj;
                if (controlBySelector == null) throw new InvalidCastException(string.Format("Type of {0} not expected Type of {1}",
                         obj.GetType().Name, typeof(T).Name));
                return controlBySelector;
            }
        }

        public static object FindControlBySelector(this BrowserWindow window,Type htmlType, string selector)
        {
            var obj = window.ExecuteScript(string.Format("return $('{0}')", selector));
            var list = obj as List<object>;
            return (list != null ? Convert.ChangeType(list.First(),htmlType) : Convert.ChangeType(obj,htmlType));
        }

        public static IEnumerable<object> FindControlsBySelector(this BrowserWindow window, Type htmlType, string selector)
        {
            var controls = (IEnumerable) window.ExecuteScript(string.Format("return $('{0}')", selector));
            return controls.Cast<object>().Select(control => Convert.ChangeType(control, htmlType));
        }

        public static string PrepareForSelector(this string input)
        {
            return input.Replace(' ', '-').Replace('.', '-');
        }
    }
}