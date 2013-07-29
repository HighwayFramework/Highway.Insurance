using System;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Web.Controls;
using Highway.Insurance.UI.Web.Controls.HtmlControls;

namespace Highway.Insurance.UI.Web
{
    /// <summary>
    /// Factory class for creating Highway.Insurance * objects
    /// </summary>
    public class EnhancedHtmlControlBaseFactory
    {
        public static T Create<T>(string sSearchProperties = null)
            where T : IEnhancedHtmlControl
        {
            Type type = typeof(T);

            if (sSearchProperties == null)
            {
                return (T)Activator.CreateInstance(type);
            }
            else
            {
                return (T)Activator.CreateInstance(type, new object[] { sSearchProperties });
            }
        }

        public static T Create<T>(WebPage webPage, string selector) where T : IEnhancedHtmlControl
        {
            Type type = typeof(T);
            return (T)Activator.CreateInstance(type, new object[] { webPage,selector });
        }
    }
}   