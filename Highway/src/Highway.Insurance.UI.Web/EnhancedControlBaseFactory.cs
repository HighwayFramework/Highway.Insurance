using System;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Web.Controls;

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
    }
}   