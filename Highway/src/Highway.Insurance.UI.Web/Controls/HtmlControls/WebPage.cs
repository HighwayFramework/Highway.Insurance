using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Web.Browsers;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    /// <summary>
    /// The browser window
    /// </summary>
    public class WebPage : BrowserWindow
    {
        public string sWindowTitle;
        private HtmlCustom mSlObjectContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPage"/> class.
        /// </summary>
        public WebPage()
            : this(null)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebPage"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        public WebPage(string title)
        {
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = GetCurrentBrowser().WindowClassName;

            SetWindowTitle(title);
        }

        /// <summary>
        /// Gets the current browser.
        /// </summary>
        /// <returns></returns>
        public static IBrowser GetCurrentBrowser()
        {
            InternetExplorer ie = new InternetExplorer();

            string currentBrowserName = BrowserWindow.CurrentBrowser;

            if (currentBrowserName == null)
            {
                //default browser
                return ie;
            }

            List<IBrowser> supportedBrowsers = new List<IBrowser>()
            {
                ie,
                new Firefox(),
                new Chrome()
            };

            IBrowser currentBrowser = supportedBrowsers.SingleOrDefault(x => currentBrowserName.StartsWith(x.Name, StringComparison.OrdinalIgnoreCase));

            if (currentBrowser == null)
            {
                //default browser
                return ie;
            }

            currentBrowser.Name = currentBrowserName;

            return currentBrowser;
        }

        /// <summary>
        /// Launches the specified url.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <returns>The launched BrowserWindow</returns>
        public static new BrowserWindow Launch(string url)
        {
            return BrowserWindow.Launch(new Uri(url));
        }

        /// <summary>
        /// Launches the specified url.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <param name="title">The title.</param>
        /// <returns>The Highway.Insurance _BrowserWindow that matches the title</returns>
        public static new WebPage Launch(string url, string title)
        {
            BrowserWindow.Launch(new Uri(url));

            return new WebPage(title);
        }

        /// <summary>
        /// Launches the specified url.
        /// </summary>
        /// <typeparam name="T">Object repository class</typeparam>
        /// <param name="url">The url.</param>
        /// <returns>An instance of the object repository class that matches the title</returns>
        public static T Launch<T>(string url)
            where T : WebPage
        {
            BrowserWindow.Launch(new Uri(url));
            
            return WebPage.GetPage<T>();
        }

        /// <summary>
        /// Launches the specified url.
        /// </summary>
        /// <typeparam name="T">Object repository class</typeparam>
        /// <param name="url">The url.</param>
        /// <returns>An instance of the object repository class that matches the title</returns>
        public static T Launch<T>(string url, string pageTitle)
            where T : WebPage
        {
            BrowserWindow.Launch(new Uri(url));

            return WebPage.GetPage<T>(pageTitle);
        }

        /// <summary>
        /// Gets the instance of T, which is an Object repository class (page definition).
        /// </summary>
        /// <typeparam name="T">Object repository class</typeparam>
        /// <returns>instance of T</returns>
        public static T GetPage<T>()
        {
            return (T)(object)ObjectRepositoryManager.GetInstance<T>();
        }

        /// <summary>
        /// Gets the instance of T, which is an Object repository class (page definition).
        /// </summary>
        /// <typeparam name="T">Object repository class</typeparam>
        /// <returns>instance of T</returns>
        public static T GetPage<T>(string title)
        {
            return (T)(object)ObjectRepositoryManager.GetInstance<T>(new object[] { title });
        }


        /// <summary>
        /// Sets the window title.
        /// </summary>
        /// <param name="title">The title.</param>
        public void SetWindowTitle(string title)
        {
            this.WindowTitles.Clear();
            this.WindowTitles.Add(title);
            this.sWindowTitle = title;
        }

        public HtmlCustom SlObjectContainer
        {
            get
            {
                if ((this.mSlObjectContainer == null))
                {
                    this.mSlObjectContainer = new HtmlCustom(this);
                    this.mSlObjectContainer.SearchProperties["TagName"] = "OBJECT";
                    this.mSlObjectContainer.WindowTitles.Add(this.sWindowTitle);
                }
                return this.mSlObjectContainer;
            }
        }

        /// <summary>
        /// Navigates to the specified URL.
        /// </summary>
        /// <param name="sUrl">The s URL.</param>
        public void NavigateToUrl(string sUrl)
        {
            this.NavigateToUrl(new Uri(sUrl));
        }

        /// <summary>
        /// Closes all instances of the current browser.
        /// </summary>
        public static void CloseAllBrowsers()
        {
            Process[] pro_list = Process.GetProcessesByName(GetCurrentBrowser().ProcessName);
            foreach (Process pro in pro_list)
            {
                //kill all open browsers
                pro.Kill();
            }
        }

        /// <summary>
        /// Run/evaluate JavaScript code in the DOM context.
        /// </summary>
        /// <param name="code">The JavaScript code</param>
        public void  RunScript(string code)
        {
            base.ExecuteScript(code);
        }

        /// <summary>
        /// Authenticates the user with the specified user name and password.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password.</param>
        public static void Authenticate(string userName, string password)
        {
            AuthenticationDialog winTemp2 = new AuthenticationDialog();
            if (winTemp2.UIUseAnotherAccountText.Exists)
            {
                Mouse.Click(winTemp2.UIUseAnotherAccountText);
            }
            winTemp2.UIUsernameEdit.Text = userName;
            winTemp2.UIPasswordEdit.Text = password;
            Mouse.Click(winTemp2.UIOKButton);
        }

        #region Objects initialized at runtime without ObjectRepository entries

        /// <summary>
        /// Gets the Highway.Insurance control object when search parameters are passed. 
        /// You don't have to create the object repository entry for this.
        /// </summary>
        /// <typeparam name="T">Pass the Highway.Insurance control you are looking for.</typeparam>
        /// <param name="searchParameters">In 'Key1=Value1;Key2=Value2' format. For example 'Id=firstname'</param>
        /// <returns>Highway.Insurance _* control object</returns>
        public T Get<T>(string searchParameters = null)
            where T : IEnhancedHtmlControl
        {
            T control = EnhancedHtmlControlBaseFactory.Create<T>(searchParameters);

            if (typeof(T).Namespace.Equals("Highway.Insurance.Controls.SilverlightControls"))
            {
                var baseControl = Activator.CreateInstance(control.GetBaseType(), new object[] { this.SlObjectContainer });
                control.Wrap(baseControl);
            }
            else if (typeof(T).Namespace.Equals("Highway.Insurance.Controls.TelerikControls"))
            {
                var baseControl = Activator.CreateInstance(control.GetBaseType(), new object[] { this.SlObjectContainer });
                (control as TelerikControls.TelerikComboBox).SetWindow(this);
            }
            else
            {
                var baseControl = Activator.CreateInstance(control.GetBaseType(), new object[] { this });
                control.Wrap(baseControl);
            }

            return control;
        }

        #endregion

        internal bool IsVisible(string selector)
        {
            return (bool) base.ExecuteScript(string.Format("return $('{0}').is(':visible')", selector));
        }

        internal HtmlControl GetParent(string selector)
        {
            return (HtmlControl) base.ExecuteScript(string.Format("return $('{0}').parent()", selector));
        }

        internal HtmlControl GetFirstChild(string selector)
        {
            object obj = base.ExecuteScript(string.Format("return $('{0}').children()", selector));
            var list = obj as List<object>;
            return (HtmlControl) (list != null ? list.First() : null);
        }

        internal HtmlControl GetNextSibling(string selector)
        {
            return (HtmlControl) base.ExecuteScript(string.Format("return $('{0}').next()", selector));
        }

        internal HtmlControl GetPreviousSibling(string selector)
        {
            return (HtmlControl) base.ExecuteScript(string.Format("return $('{0}').prev()", selector));
        }
        
        internal IEnumerable<HtmlControl> GetChildControls(string selector)
        {
            object obj = base.ExecuteScript(string.Format("return $('{0}').children()", selector));
            var list = obj as List<object>;
            return (list != null ? list.OfType<HtmlControl>() : null);
        }


        public bool CurrentlyExists<T>(EnhancedHtmlControl<T> control) where T : HtmlControl
        {
            object obj = base.ExecuteScript(string.Format("return $('{0}')", control.Selector));
            var list = obj as List<object>;
            if (list != null) return list.Any();
            return obj != null;
        }


    }
}
