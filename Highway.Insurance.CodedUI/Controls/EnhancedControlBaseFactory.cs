using System;

namespace Highway.Insurance.UI.Controls
{
    /// <summary>
    /// Factory class for creating CUITe* objects
    /// </summary>
    public class EnhancedControlBaseFactory
    {
        public static T Create<T>(string sSearchProperties = null)
            where T : IEnhancedControlBase
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