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
        /// <returns>The CUITe_BrowserWindow that matches the title</returns>
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
            
            return WebPage.GetBrowserWindow<T>();
        }

        /// <summary>
        /// Gets the instance of T, which is an Object repository class (page definition).
        /// </summary>
        /// <typeparam name="T">Object repository class</typeparam>
        /// <returns>instance of T</returns>
        public static T GetBrowserWindow<T>()
        {
            return (T)(object)ObjectRepositoryManager.GetInstance<T>();
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
        /// Gets the CUITe control object when search parameters are passed. 
        /// You don't have to create the object repository entry for this.
        /// </summary>
        /// <typeparam name="T">Pass the CUITe control you are looking for.</typeparam>
        /// <param name="searchParameters">In 'Key1=Value1;Key2=Value2' format. For example 'Id=firstname'</param>
        /// <returns>CUITe_* control object</returns>
        public T Get<T>(string searchParameters = null)
            where T : IEnhancedControlBase
        {
            T control = EnhancedControlBaseFactory.Create<T>(searchParameters);

            if (typeof(T).Namespace.Equals("CUITe.Controls.SilverlightControls"))
            {
                var baseControl = Activator.CreateInstance(control.GetBaseType(), new object[] { this.SlObjectContainer });
                control.Wrap(baseControl);
            }
            else if (typeof(T).Namespace.Equals("CUITe.Controls.TelerikControls"))
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

        [Obsolete("GetHtmlButton(string) is deprecated, please use Get<CUITe_HtmlButton>(string) instead.")]
        public EnhancedHtmlButton GetHtmlButton(string searchParameters)
        {
            EnhancedHtmlButton button = new EnhancedHtmlButton(searchParameters);
            button.Wrap(new HtmlButton(this));
            return button;
        }

        [Obsolete("GetHtmlCell(string) is deprecated, please use Get<CUITe_HtmlCell>(string) instead.")]
        public EnhancedHtmlCell GetHtmlCell(string searchParameters)
        {
            EnhancedHtmlCell cell = new EnhancedHtmlCell(searchParameters);
            cell.Wrap(new HtmlCell(this));
            return cell;
        }

        [Obsolete("GetHtmlCheckBox(string) is deprecated, please use Get<CUITe_HtmlCheckBox>(string) instead.")]
        public EnhancedHtmlCheckBox GetHtmlCheckBox(string searchParameters)
        {
            EnhancedHtmlCheckBox chk = new EnhancedHtmlCheckBox(searchParameters);
            chk.Wrap(new HtmlCheckBox(this));
            return chk;
        }

        [Obsolete("GetHtmlComboBox(string) is deprecated, please use Get<CUITe_HtmlComboBox>(string) instead.")]
        public EnhancedHtmlComboBox GetHtmlComboBox(string searchParameters)
        {
            EnhancedHtmlComboBox cmb = new EnhancedHtmlComboBox(searchParameters);
            cmb.Wrap(new HtmlComboBox(this));
            return cmb;
        }

        [Obsolete("GetHtmlDiv(string) is deprecated, please use Get<CUITe_HtmlDiv>(string) instead.")]
        public EnhancedHtmlDiv GetHtmlDiv(string searchParameters)
        {
            EnhancedHtmlDiv div = new EnhancedHtmlDiv(searchParameters);
            div.Wrap(new HtmlDiv(this));
            return div;
        }

        [Obsolete("GetHtmlEdit(string) is deprecated, please use Get<CUITe_HtmlEdit>(string) instead.")]
        public EnhancedHtmlEdit GetHtmlEdit(string searchParameters)
        {
            EnhancedHtmlEdit edit = new EnhancedHtmlEdit(searchParameters);
            edit.Wrap(new HtmlEdit(this));
            return edit;
        }

        [Obsolete("GetHtmlFileInput(string) is deprecated, please use Get<CUITe_HtmlFileInput>(string) instead.")]
        public EnhancedHtmlFileInput GetHtmlFileInput(string searchParameters)
        {
            EnhancedHtmlFileInput fin = new EnhancedHtmlFileInput(searchParameters);
            fin.Wrap(new HtmlFileInput(this));
            return fin;
        }

        [Obsolete("GetHtmlHyperlink(string) is deprecated, please use Get<CUITe_HtmlHyperlink>(string) instead.")]
        public EnhancedHtmlHyperlink GetHtmlHyperlink(string searchParameters)
        {
            EnhancedHtmlHyperlink href = new EnhancedHtmlHyperlink(searchParameters);
            href.Wrap(new HtmlHyperlink(this));
            return href;
        }

        [Obsolete("GetHtmlImage(string) is deprecated, please use Get<CUITe_HtmlImage>(string) instead.")]
        public EnhancedHtmlImage GetHtmlImage(string searchParameters)
        {
            EnhancedHtmlImage img = new EnhancedHtmlImage(searchParameters);
            img.Wrap(new HtmlImage(this));
            return img;
        }

        [Obsolete("GetHtmlInputButton(string) is deprecated, please use Get<CUITe_HtmlInputButton>(string) instead.")]
        public EnhancedHtmlInputButton GetHtmlInputButton(string searchParameters)
        {
            EnhancedHtmlInputButton input = new EnhancedHtmlInputButton(searchParameters);
            input.Wrap(new HtmlInputButton(this));
            return input;
        }

        [Obsolete("GetHtmlLabel(string) is deprecated, please use Get<CUITe_HtmlLabel>(string) instead.")]
        public EnhancedHtmlLabel GetHtmlLabel(string searchParameters)
        {
            EnhancedHtmlLabel lbl = new EnhancedHtmlLabel(searchParameters);
            lbl.Wrap(new HtmlLabel(this));
            return lbl;
        }

        [Obsolete("GetHtmlList(string) is deprecated, please use Get<CUITe_HtmlList>(string) instead.")]
        public EnhancedHtmlList GetHtmlList(string searchParameters)
        {
            EnhancedHtmlList lst = new EnhancedHtmlList(searchParameters);
            lst.Wrap(new HtmlList(this));
            return lst;
        }

        [Obsolete("GetHtmlPassword(string) is deprecated, please use Get<CUITe_HtmlPassword>(string) instead.")]
        public EnhancedHtmlPassword GetHtmlPassword(string searchParameters)
        {
            EnhancedHtmlPassword pwd = new EnhancedHtmlPassword(searchParameters);
            HtmlEdit tmp = new HtmlEdit(this);
            tmp.FilterProperties[HtmlEdit.PropertyNames.Type] = "PASSWORD";
            pwd.Wrap(tmp);
            return pwd;
        }

        [Obsolete("GetHtmlRadioButton(string) is deprecated, please use Get<CUITe_HtmlRadioButton>(string) instead.")]
        public EnhancedHtmlRadioButton GetHtmlRadioButton(string searchParameters)
        {
            EnhancedHtmlRadioButton rad = new EnhancedHtmlRadioButton(searchParameters);
            rad.Wrap(new HtmlRadioButton(this));
            return rad;
        }

        [Obsolete("GetHtmlSpan(string) is deprecated, please use Get<CUITe_HtmlSpan>(string) instead.")]
        public EnhancedHtmlSpan GetHtmlSpan(string searchParameters)
        {
            EnhancedHtmlSpan span = new EnhancedHtmlSpan(searchParameters);
            span.Wrap(new HtmlSpan(this));
            return span;
        }

        [Obsolete("GetHtmlTable(string) is deprecated, please use Get<CUITe_HtmlTable>(string) instead.")]
        public EnhancedHtmlTable GetHtmlTable(string searchParameters)
        {
            EnhancedHtmlTable tbl = new EnhancedHtmlTable(searchParameters);
            tbl.Wrap(new HtmlTable(this));
            return tbl;
        }

        [Obsolete("GetHtmlTextArea(string) is deprecated, please use Get<CUITe_HtmlTextArea>(string) instead.")]
        public EnhancedHtmlTextArea GetHtmlTextArea(string searchParameters)
        {
            EnhancedHtmlTextArea tarea = new EnhancedHtmlTextArea(searchParameters);
            tarea.Wrap(new HtmlTextArea(this));
            return tarea;
        }

        #endregion
    }
}
