using System;
using System.Linq;
using System.Reflection;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Web.Controls.HtmlControls;
using Highway.Insurance.UI.Web.Controls.TelerikControls;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web
{
    public class ObjectRepositoryManager
    {
        public static T GetInstance<T>()
        {
            return (T)(object)GetInstance(typeof(T));
        }

        public static T GetInstance<T>(params object[] args)
        {
            return (T)(object)ObjectRepositoryManager.GetInstance(typeof(T), args);
        }

        private static WebPage GetInstance(Type typePageDefinition)
        {
            return GetInstance(typePageDefinition, null);
        }

        private static WebPage GetInstance(Type typePageDefinition, params object[] args)
        {
            WebPage browserWindow = (WebPage)Activator.CreateInstance(typePageDefinition, args);

            browserWindow.SetWindowTitle(typePageDefinition.GetField("sWindowTitle").GetValue(browserWindow).ToString());

            FieldInfo[] finfo = browserWindow.GetType().GetFields();
            foreach (FieldInfo fieldinfo in finfo) 
            {
                Type fieldType = fieldinfo.FieldType;

                if (fieldType.IsAssignableFrom(typeof(TelerikComboBox)))
                {
                    TelerikComboBox field = (TelerikComboBox)fieldinfo.GetValue(browserWindow);
                    field.SetWindow(browserWindow);
                }
                else if (fieldType.GetInterfaces().Contains(typeof(IEnhancedControlBase)))
                {
                    IEnhancedControlBase field = (IEnhancedControlBase)fieldinfo.GetValue(browserWindow);

                    if (field.GetBaseType().IsSubclassOf(typeof(HtmlControl)))
                    {
                        field.Wrap(Activator.CreateInstance(field.GetBaseType(), new object[] { browserWindow }));
                    }
                }
            }
            return browserWindow;
        }
    }
}