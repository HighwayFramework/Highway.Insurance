using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Highway.Insurance.UI.Web.Controls;
using Highway.Insurance.UI.Web.Controls.HtmlControls;
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
            return ExtractTypeFromReturn<T>(obj);
        }

        private static T ExtractTypeFromReturn<T>(object obj) where T : HtmlControl
        {
            var list = obj as List<object>;

            if (list != null)
            {
                if (list.OfType<T>().FirstOrDefault() == null)
                    throw new InvalidCastException(string.Format("Type of {0} - {1}  not expected Type of {2}",
                                                                 obj.GetType().Name, ExtractTypeFromList(list).Name,
                                                                 typeof (T).Name));
                return list.OfType<T>().First();
            }
            var controlBySelector = (T) obj;
            if (controlBySelector == null)
            {
                throw new InvalidCastException(string.Format("Type of {0} not expected Type of {1}",
                                                             obj.GetType().Name, typeof (T).Name));
            }
            return controlBySelector;
        }
        
        private static Type ExtractTypeFromList(List<object> list)
        {
            Type itemType = list.First().GetType();
            return itemType;
        }

        public static object FindControlBySelector(this BrowserWindow window, Type htmlType, string selector)
        {
            var obj = window.ExecuteScript(string.Format("return $('{0}')", selector));
            var list = obj as List<object>;
            return (list != null ? Convert.ChangeType(list.First(), htmlType) : Convert.ChangeType(obj, htmlType));
        }

        public static IEnumerable<object> FindControlsBySelector(this BrowserWindow window, Type htmlType, string selector)
        {
            var controls = (IEnumerable)window.ExecuteScript(string.Format("return $('{0}')", selector));
            return controls.Cast<object>().Select(control => Convert.ChangeType(control, htmlType));
        }

        public static string PrepareForSelector(this string input)
        {
            return input.Replace(' ', '-').Replace('.', '-');
        }


        public static bool IsVisible(this BrowserWindow window, string selector)
        {
            return (bool)window.ExecuteScript(string.Format("return jQuery('{0}').is(':visible')", selector));
        }

        public static HtmlControl GetParent(this BrowserWindow window, string selector)
        {
            return (HtmlControl)window.ExecuteScript(string.Format("return jQuery('{0}').parent()", selector));
        }

        public static HtmlControl GetFirstChild(this BrowserWindow window, string selector)
        {
            object obj = window.ExecuteScript(string.Format("return jQuery('{0}').children()", selector));
            var list = obj as List<object>;
            return (HtmlControl)(list != null ? list.First() : null);
        }

        public static HtmlControl GetNextSibling(this BrowserWindow window, string selector)
        {
            return (HtmlControl)window.ExecuteScript(string.Format("return jQuery('{0}').next()", selector));
        }

        public static HtmlControl GetPreviousSibling(this BrowserWindow window, string selector)
        {
            return (HtmlControl)window.ExecuteScript(string.Format("return jQuery('{0}').prev()", selector));
        }

        public static IEnumerable<HtmlControl> GetChildControls(this BrowserWindow window, string selector)
        {
            object obj = window.ExecuteScript(string.Format("return jQuery('{0}').children()", selector));
            var list = obj as List<object>;
            return (list != null ? list.OfType<HtmlControl>() : null);
        }

        public static bool CurrentlyExists<T>(this BrowserWindow window, EnhancedHtmlControl<T> control) where T : HtmlControl
        {
            object obj = window.ExecuteScript(string.Format("return jQuery('{0}')", control.Selector));
            var list = obj as List<object>;
            if (list != null)
            {
                return list.Any();
            }
            else
            {

            }
            return obj != null;
        }

    }
}