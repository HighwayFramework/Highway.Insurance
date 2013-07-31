using System.Diagnostics;
using System.IO;
using System.Linq;
using Example.UI.Web.Tests.ObjectRepository;
using Highway.Insurance.UI.Web.Controls.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.UI.Web.Tests
{
    [CodedUITest]
    [DeploymentItem(@"TestHtml\TestHtmlPage.html")]
    [DeploymentItem(@"TestHtml\TitleTest.html")]
    [DeploymentItem(@"TestHtml\DynamicBrowserWindowTitle.html")]
    [DeploymentItem(@"TestHtml\DynamicBrowserWindowTitle.1.html")]
    [DeploymentItem(@"TestHtml\DynamicBrowserWindowTitle.2.html")]
    public class BrowserWindowTests
    {
        private readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        [TestMethod]
        public void FromProcess_GetWindowTitle_Succeeds()
        {
            //Arrange
            WebPage.Launch(CurrentDirectory + "/TitleTest.html");

            //Act
            BrowserWindow bWin =
                WebPage.FromProcess(
                    Process.GetProcessesByName("iexplore").Single(x => !string.IsNullOrEmpty(x.MainWindowTitle)));

            //Assert
            Assert.AreEqual("A Test - Windows Internet Explorer", bWin.Title);

            bWin.Close();

        }

        [TestMethod]
        public void Launch_GetWindowTitle_Succeeds()
        {
            //Arrange
            string url = CurrentDirectory + "/TestHtmlPage.html";
            string windowTitle = "A Test";
            string fullWindowTitle = string.Format("{0} - Windows Internet Explorer", windowTitle);

            //Act
            TestHtmlPage window = WebPage.Launch<TestHtmlPage>(url);

            //Assert
            Assert.AreEqual(fullWindowTitle, window.Title);

            window.Close();
        }

        [TestMethod]
        public void ShouldFindVisible()
        {
            //Arrange
            string url = CurrentDirectory + "/TestHtmlPage.html";
            string windowTitle = "A Test";
            string fullWindowTitle = string.Format("{0} - Windows Internet Explorer", windowTitle);

            //Act
            TestHtmlPage window = WebPage.Launch<TestHtmlPage>(url);

            //Assert
            Assert.IsFalse(window.hidden.IsVisible());
            Assert.IsFalse(window.displayNone.IsVisible());


            window.Close();
        }

        [Ignore] // TODO: use known html
        [TestMethod]
        [WorkItem(608)]
        public void GenericGet_WithHtmlControls_GetsControlsDynamically()
        {
            //Arrange
            WebPage bWin = WebPage.Launch("http://mail.google.com", "Gmail: Email from Google");

            //Act
            bWin.Get<EnhancedHtmlEdit>("Id=Email").SetText("xyz@gmail.com");
            bWin.Get<EnhancedHtmlPassword>("Id=Password").SetText("MyPa$$Word");
            bWin.Get<EnhancedHtmlInputButton>("Id=signIn").Click();
            bWin.Close();
        }

        [TestMethod]
        public void GetBrowserWindow_WithDynamicWindowTitle_CanGetNewWindowTitle()
        {
            string page1GenericWindowTitle = "window title 1";
            string page1FullWindowTitle = "window title 1 - Windows Internet Explorer";

            //Arrange
            DynamicBrowserWindowTitleRepository home =
                WebPage.Launch<DynamicBrowserWindowTitleRepository>(CurrentDirectory + "/DynamicBrowserWindowTitle.html");

            home.btnGoToPage1.Click();

            //Act
            DynamicBrowserWindowTitleRepository page1 =
                WebPage.GetPage<DynamicBrowserWindowTitleRepository>(page1GenericWindowTitle);

            //Assert
            Assert.AreEqual(page1FullWindowTitle, page1.Title);

            page1.Close();
        }

        [TestMethod]
        [WorkItem(607)]
        public void GetBrowserWindow_WithDynamicWindowTitle_CanInteractWithWindow()
        {
            //Arrange
            string page2GenericWindowTitle = "window title 2";
            string page2DynamicGenericWindowTitle = "the window title changed";
            string page2DynamicFullWindowTitle = "the window title changed - Windows Internet Explorer";
            string homePageGenericWindowTitle = "Clicking the buttons changes the window title";
            string homePageFullWindowTitle = "Clicking the buttons changes the window title - Windows Internet Explorer";

            DynamicBrowserWindowTitleRepository home =
                WebPage.Launch<DynamicBrowserWindowTitleRepository>(CurrentDirectory + "/DynamicBrowserWindowTitle.html");

            home.btnGoToPage2.Click();

            DynamicBrowserWindowTitleRepository page2 =
                WebPage.GetPage<DynamicBrowserWindowTitleRepository>(page2GenericWindowTitle);

            page2.btnChangeWindowTitle.Click();

            //Checkpoint
            Assert.AreEqual(page2DynamicFullWindowTitle, page2.Title);

            //Act
            page2 =
                WebPage.GetPage<DynamicBrowserWindowTitleRepository>(
                    page2DynamicGenericWindowTitle);

            page2.btnGoToHomePage.Click();

            page2.SetWindowTitle(homePageGenericWindowTitle);

            //Assert
            Assert.AreEqual(homePageFullWindowTitle, page2.Title);

            page2.Close();
        }

        [TestMethod]
        public void GetHtmlDocument_FromBrowserWindow_CanGetOuterHtmlProperty()
        {
            //Arrange
            TestHtmlPage window = WebPage.Launch<TestHtmlPage>(CurrentDirectory + "/TestHtmlPage.html");

            //Act
            EnhancedHtmlDocument doc = window.Get<EnhancedHtmlDocument>();

            //Assert
            string expected = "<BODY>";

            Assert.AreEqual(expected, doc.UnWrap().GetProperty("OuterHtml").ToString().Substring(0, expected.Length),
                            true);

            window.Close();
        }

        [TestMethod]
        public void CloseBrowserWindow_UsingLaunchedBrowserWindow_Succeeds()
        {
            TestHtmlPage window = WebPage.Launch<TestHtmlPage>(CurrentDirectory + "/TestHtmlPage.html");

            window.Close();
        }

        [TestMethod]
        public void FromProcess_FindAllBrowserWindows_CanGetUriAndTitle()
        {
            Process[] processes = Process.GetProcessesByName("iexplore");
            foreach (Process process in processes)
            {
                if (string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    continue;
                }

                BrowserWindow bWin = WebPage.FromProcess(process);

                Trace.WriteLine(string.Format("Found browser window: {0} {1}", bWin.Uri, bWin.Title));
            }
        }
    }
}