using System;

namespace Highway.Insurance.UI.Controls
{
    /// <summary>
    /// Factory class for creating Highway.Insurance * objects
    /// </summary>
    public class EnhancedControlBaseFactory
    {
        public static T Create<T>(string sSearchProperties = null, SelectorType selectorType = SelectorType.Default)
            where T : IEnhancedControlBase
        {
            Type type = typeof(T);

            if (sSearchProperties == null)
            {
                return (T)Activator.CreateInstance(type);
            }
            else
            {
                return (T)Activator.CreateInstance(type, new object[] { sSearchProperties, selectorType });
            }
        }
    }
}   