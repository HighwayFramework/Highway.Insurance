using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Example.UI.Web.Tests.ObjectRepository;
using Highway.Insurance.UI;
using Highway.Insurance.UI.Controls;
using Highway.Insurance.UI.Exceptions;
using Highway.Insurance.UI.Web.Browsers;
using Highway.Insurance.UI.Web.Controls.HtmlControls;
using Highway.Insurance.UI.Windows.Controls.WinForms;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.UI.Web.Tests
{
    [CodedUITest]
    [DeploymentItem(@"Sample_CUITeTestProject\XMLFile2.xml")]
    [DeploymentItem(@"Sample_CUITeTestProject\TestHtmlPage.html")]
    public class HtmlControlTests
    {
        private readonly string CurrentDirectory = Directory.GetCurrentDirectory();

        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            //WebPage.CloseAllBrowsers();
        }

        [Ignore] //TODO: use known html
        [TestMethod]
        public void HtmlEdit_SetText_Succeeds()
        {
            GoogleHomePage pgGHomePage = WebPage.Launch<GoogleHomePage>("http://www.google.com");
            pgGHomePage.txtSearch.SetText("Coded UI Test Framework");
            GoogleSearch pgSearch = WebPage.GetPage<GoogleSearch>();
            UITestControlCollection col = pgSearch.divSearchResults.UnWrap().GetChildren();
            //do something with collection
            pgSearch.Close();
        }

        [TestMethod]
        public void DataManager_GetDataRowUsingEmbeddedResource_Succeeds()
        {
            Hashtable ht = EnhancedDataManager.GetDataRow(Type.GetType("Sample_CUITeTestProject.HtmlControlTests"),
                                                              "XMLFile1.xml", "tc2");
            Assert.AreEqual("test", ht["test"]);
            Assert.AreEqual("Kondapur, Hyderabad", ht["address"]);
            Assert.AreEqual("Suresh", ht["firstname"]);
            Assert.AreEqual("Balasubramanian", ht["lastname"]);
            Assert.AreEqual("04/19/1973", ht["dob"]);
            Assert.AreEqual("37", ht["age"]);
            Assert.AreEqual("Indian", ht["nationality"]);
        }

        //[TestMethod]
        //public void DataManager_GetDataRowUsingFile_Succeeds()
        //{
        //    Hashtable ht = CUITe.EnhancedDataManager.GetDataRow("XMLFile2.xml", "content2");
        //    Assert.AreEqual("SomeTest", ht["test"]);
        //    Assert.AreEqual("Somewhere, Somewhere", ht["address"]);
        //    Assert.AreEqual("SomeFirstName", ht["firstname"]);
        //    Assert.AreEqual("SomeLastNameBigger", ht["lastname"]);
        //    Assert.AreEqual("01/01/1900", ht["dob"]);
        //    Assert.AreEqual("101", ht["age"]);
        //    Assert.AreEqual("USA", ht["nationality"]);
        //}


        [TestMethod]
        [WorkItem(588)]
        public void HtmlControl_WithInvalidSearchProperties_ThrowsInvalidSearchKeyException()
        {
            //TODO: use known html
            try
            {
                GoogleHomePageWithInvalidControlSearchProperties pgGHome =
                    WebPage.Launch<GoogleHomePageWithInvalidControlSearchProperties>("http://www.google.com");

                Assert.Fail("HighwayInsuranceInvalidSearchKey not thrown");
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine(ex.ToString());

                Assert.AreEqual(typeof (HighwayInsuranceInvalidSearchKey), ex.InnerException.GetType());
            }
        }

        [TestMethod]
        public void HtmlControl_NonExistent_DoesNotExist()
        {
            //Arrange
            var smartMatchOptions = SmartMatchOptions.Control;

            try
            {
                //set SmartMatchOptions to None because we are using .Exists on an invalid control
                //remember previous setting so that it can be reset
                smartMatchOptions = Playback.PlaybackSettings.SmartMatchOptions;
                Playback.PlaybackSettings.SmartMatchOptions = SmartMatchOptions.None;

                using (var tempFile = new TempFile(
                    @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
    </body>
</html>"))
                {
                    WebPage.Launch(tempFile.FilePath);
                    var window = new WebPage("test");

                    //Act
                    EnhancedHtmlDiv div = window.Get<EnhancedHtmlDiv>("Id=invalid");

                    //Assert
                    Assert.IsFalse(div.Exists);

                    window.Close();
                }
            }
            finally
            {
                //reset default setting
                Playback.PlaybackSettings.SmartMatchOptions = smartMatchOptions;
            }
        }

        [Ignore] //TODO: use known html
        [TestMethod]
        [WorkItem(589)]
        public void HtmlEdit_Wrap_Succeeds()
        {
            GoogleHomePage pgGHomePage = WebPage.Launch<GoogleHomePage>("http://www.google.com");

            var tmp = new HtmlEdit(pgGHomePage);
            tmp.SearchProperties.Add("Id", "lst-ib");

            var txtEdit = new EnhancedHtmlEdit();
            txtEdit.WrapReady(tmp);
            txtEdit.SetText("Coded UI Test enhanced Framework");
            GoogleSearch pgSearch = WebPage.GetPage<GoogleSearch>();
            pgSearch.Close();
        }

        [TestMethod]
        public void HtmlTable_GetColumnHeaders_Succeeds()
        {
            WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html");
            var bWin = new WebPage("A Test");
            EnhancedHtmlTable tbl = bWin.Get<EnhancedHtmlTable>("id=calcWithHeaders");
            var saExpectedValues = new[] {"Header1", "Header2", "Header3"};
            string[] saHeaders = tbl.GetColumnHeaders();
            Assert.AreEqual(saExpectedValues[0], saHeaders[0]);
            Assert.AreEqual(saExpectedValues[1], saHeaders[1]);
            Assert.AreEqual(saExpectedValues[2], saHeaders[2]);
            bWin.Close();
        }

        [TestMethod]
        public void HtmlTable_FindHeaderAndClick_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <table style=""width: 100%;"" id=""tableId"">
            <tbody>
                <tr>
                    <td>Commitment</td>
                    <th>September</th>
                    <th>October</th>
                    <th>November</th>
                    <td>Total</td>
                </tr>
                <tr>
                    <td>Beginning Balance</td>
                    <td>¥21,570,253</td>
                    <td>¥21,375,491</td>
                    <td>¥21,200,873</td>
                    <td></td>
                </tr>
                <tr>
                    <td>New Purchases</td>
                    <td>¥0</td>
                    <td>¥0</td>
                    <td>¥0</td>
                    <td></td>
                </tr>
                <tr>
                    <td>Utilized</td>
                    <td>¥194,762</td>
                    <td>¥174,618</td>
                    <td>¥0</td>
                    <td>¥369,380</td>
                </tr>
                <tr>
                    <td>Ending Balance</td>
                    <td>¥21,375,491</td>
                    <td>¥21,200,873</td>
                    <td>¥21,200,873</td>
                    <td></td>
                </tr>
                <tr>
                    <td><b>Overage</b></td> 
                    <td>¥0</td>
                    <td>¥0</td>
                    <td>¥0</td>
                    <td>¥0</td>
                    <td></td>
                </tr>
                <tr>
                    <td><b>Total Usage</b></td>
                    <td>¥194,762</td>
                    <td>¥174,618</td>
                    <td>¥0</td>
                    <td>¥369,380</td>
                </tr>
            </tbody>
        </table>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlTable table = window.Get<EnhancedHtmlTable>("id=tableId");

                //Act
                table.FindHeaderAndClick(0, 2);

                window.Close();
            }
        }

        [TestMethod]
        public void HtmlTable_ColumnCount_Succeeds()
        {
            WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html");
            var bWin = new WebPage("A Test");
            EnhancedHtmlTable tbl = bWin.Get<EnhancedHtmlTable>("id=calcWithHeaders");
            Assert.AreEqual(3, tbl.ColumnCount);
            bWin.Close();
        }

        [TestMethod]
        public void HtmlTable_ClickOnColumnHeader_Succeeds()
        {
            WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html");
            var bWin = new WebPage("A Test");
            EnhancedHtmlTable tbl = bWin.Get<EnhancedHtmlTable>("id=tableWithAlertOnHeaderClick");
            tbl.FindHeaderAndClick(0, 0);
            bWin.PerformDialogAction(BrowserDialogAction.Ok);
            bWin.Close();
        }

        [TestMethod]
        [WorkItem(638)]
        public void HtmlTable_FindRowUsingTableWithRowHeaders_Succeeds()
        {
            WebPage bWin = WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html", "A Test");
            EnhancedHtmlTable tbl = bWin.Get<EnhancedHtmlTable>("id=calcWithHeaders");
            tbl.FindRowAndClick(2, "9", EnhancedHtmlTableSearchOptions.NormalTight);
            Assert.AreEqual("9", tbl.GetCellValue(3, 2).Trim());
            bWin.Close();
        }

        [TestMethod]
        [WorkItem(638)]
        public void HtmlTable_FindRowUsingTableWithoutRowHeaders_Succeeds()
        {
            WebPage bWin = WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html", "A Test");
            EnhancedHtmlTable tbl = bWin.Get<EnhancedHtmlTable>("id=calcWithOutHeaders");
            tbl.FindRowAndClick(2, "9", EnhancedHtmlTableSearchOptions.NormalTight);
            Assert.AreEqual("9", tbl.GetCellValue(2, 2).Trim());
            bWin.Close();
        }

        [TestMethod]
        public void HtmlTable_GetCellValueWithHeaderCell_Succeeds()
        {
            WebPage bWin = WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html", "A Test");

            EnhancedHtmlTable termTable = bWin.Get<EnhancedHtmlTable>("Id=calcWithHeaderCells");

            Assert.AreEqual("3", termTable.GetCellValue(1, 1));

            bWin.Close();
        }

        [TestMethod]
        public void HtmlTable_GetCellValueUsingTableWithTHInTBODY_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <table id=""tableId"" border=""1"">
            <tbody>
                <tr>
                    <th>Lun</th>
                    <th>Used Space</th>
                    <th>Free Space</th>
                    <th>Usage %</th>
                    <th>&nbsp;</th>
                </tr>
                <tr>
                    <td>LUN_04</td>
                    <td>26534605227</td>
                    <td>15405750418</td>
                    <td>
                        <dl>
                            <dd>
                                <dl>
                                    <dd>
                                        <span>64.27%</span>
                                    </dd>
                                </dl>
                            </dd>
                        </dl>
                    </td>
                    <td></td>
                </tr>
            </tbody>
        </table>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlTable table = window.Get<EnhancedHtmlTable>("id=tableId");

                //Act
                table.FindRowAndClick(0, "LUN_04", EnhancedHtmlTableSearchOptions.NormalTight);

                //Assert
                Assert.AreEqual("LUN_04", table.GetCellValue(1, 0).Trim());

                window.Close();
            }
        }

        [TestMethod]
        public void HtmlInputButton_UsingSearchParameterWithValueAsKey_Succeeds()
        {
            //Internet Explorer may display the message: Internet Explorer restricted this webpage from running scripts or ActiveX controls.
            //This security restriction prevents the alert message to appear.
            //To enable running scripts on the local computer, go to Tools > Internet options > Advanced > Security > [checkmark] Allow active content to run in files on My Computer

            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <input type=""submit"" value=""Log In"" onclick=""alert('onclick');""/>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlInputButton button = window.Get<EnhancedHtmlInputButton>("Value=Log In");

                //Act
                button.Click();

                if (WebPage.GetCurrentBrowser() is InternetExplorer)
                {
                    //read JavaScript alert text
                    var popup = new EnhancedWinWindow("ClassName=#32770;Name=Message from webpage");
                    EnhancedWinText text = popup.Get<EnhancedWinText>();
                    Assert.AreEqual("onclick", text.DisplayText);
                }

                window.PerformDialogAction(BrowserDialogAction.Ok);

                window.Close();
            }
        }

        [TestMethod]
        public void PointAndClick_OnHtmlInputButton_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <input type=""submit"" value=""Log In"" onclick=""alert('onclick');""/>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlInputButton button = window.Get<EnhancedHtmlInputButton>("Value=Log In");

                //Act
                button.Click();

                window.PerformDialogAction(BrowserDialogAction.Ok);

                window.Close();
            }
        }

        [TestMethod]
        public void HtmlFileInput_SetFile_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <input name=""inputName"" type=""file"" id=""inputId"" />
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlFileInput fileInput = window.Get<EnhancedHtmlFileInput>("Id=inputId");

                string tempInputFilePath = Path.GetTempFileName();

                //Act
                fileInput.SetFile(tempInputFilePath);

                window.Close();

                File.Delete(tempInputFilePath);
            }
        }

        [TestMethod]
        [Ignore]
        public void HtmlHyperlink_OnSharePoint2010_Succeeds()
        {
            WebPage.Launch("http://myasia/sites/sureba/Default.aspx");
            WebPage.Authenticate("username", "passwd");
            var bWin = new WebPage("Suresh Balasubramanian");
            bWin.Get<EnhancedHtmlHyperlink>("Id=idHomePageNewDocument").Click();
            var closeLink = bWin.Get<EnhancedHtmlHyperlink>("Title=Close;class=ms-dlgCloseBtn");
            //clicking closeLink directly doesn't work as the maximizeLink is clicked due to the controls being placed too close to each other
            Mouse.Click(closeLink.UnWrap().GetChildren()[0].GetChildren()[0]);
            bWin.RunScript(@"STSNavigate2(event,'/sites/sureba/_layouts/SignOut.aspx');");
        }

        [TestMethod]
        public void HtmlControl_GetChildren_Succeeds()
        {
            WebPage bWin = WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html", "A Test");
            var div = bWin.Get<EnhancedHtmlDiv>("id=calculatorContainer1");
            var col = div.GetChildren();
            Assert.IsTrue(col[0].GetBaseType().Name == "HtmlDiv");
            Assert.IsTrue(col[1].GetBaseType().Name == "HtmlTable");
            Assert.IsTrue(((EnhancedHtmlDiv) col[0]).InnerText == "calcWithHeaders");
            var tbl = (EnhancedHtmlTable) col[1];
            Assert.AreEqual("6", tbl.GetCellValue(2, 2).Trim());
            bWin.Close();
        }

        [TestMethod]
        public void HtmlParagraph_InnertText_Succeeds()
        {
            WebPage bWin = WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html", "A Test");
            Assert.IsTrue(bWin.Get<EnhancedHtmlParagraph>("Id=para1").InnerText.Contains("EnhancedHtmlParagraph"));
            bWin.Close();
        }

        [TestMethod]
        public void HtmlComboBox_Items_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <select id=""selectId"">
            <option>Cricket</option>
            <option>Football</option>
            <option>Tennis</option>
        </select>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                //Act
                EnhancedHtmlComboBox comboBox = window.Get<EnhancedHtmlComboBox>("Id=selectId");

                //Assert
                Assert.AreEqual("Football", comboBox.Items[1]);
                Assert.IsTrue(comboBox.ItemExists("Cricket"));

                window.Close();
            }
        }

        [TestMethod]
        public void SelectItem_ByIndexOnHtmlComboBox_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <select id=""selectId"">
            <option>Cricket</option>
            <option>Football</option>
            <option>Tennis</option>
        </select>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                //Act
                EnhancedHtmlComboBox comboBox = window.Get<EnhancedHtmlComboBox>("Id=selectId");

                comboBox.SelectItem(1);

                //Assert
                Assert.AreEqual("Football", comboBox.SelectedItem);

                window.Close();
            }
        }

        [TestMethod]
        public void HtmlParagraph_InObjectRepository_Succeeds()
        {
            TestHtmlPage testpage = WebPage.Launch<TestHtmlPage>(CurrentDirectory + "/TestHtmlPage.html");
            string content = testpage.p.InnerText;
            Assert.IsTrue(content.Contains("EnhancedHtmlParagraph"));
            testpage.Close();
        }

        [TestMethod]
        public void HtmlParagraph_TraverseSiblingsParentAndChildren_Succeeds()
        {
            WebPage bWin = WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html", "A Test");
            var p = bWin.Get<EnhancedHtmlParagraph>("Id=para1");
            Assert.IsTrue(((EnhancedHtmlEdit) p.PreviousSibling).UnWrap().Name == "text1_test");
            Assert.IsTrue(((EnhancedHtmlInputButton) p.NextSibling).ValueAttribute == "sample button");
            Assert.IsTrue(((EnhancedHtmlDiv) p.Parent).UnWrap().Id == "parentdiv");
            Assert.IsTrue(((EnhancedHtmlPassword) p.Parent.FirstChild).UnWrap().Name == "pass");
            bWin.Close();
        }

        [TestMethod]
        [DeploymentItem(@"Sample_CUITeTestProject\iframe_test.html")]
        [DeploymentItem(@"Sample_CUITeTestProject\iframe.html")]
        public void HtmlInputButton_ClickInIFrame_Succeeds()
        {
            WebPage bWin = WebPage.Launch(CurrentDirectory + "/iframe_test.html", "iframe Test Main");
            bWin.Get<EnhancedHtmlInputButton>("Value=Log In").Click();
            bWin.Close();
        }

        [TestMethod]
        [WorkItem(882)]
        public void HtmlInputButton_GetWithValueContainingWhitespace_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <input name=""inputName"" type=""submit"" value=""   Search   "" />
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlInputButton button = window.Get<EnhancedHtmlInputButton>("Value=   Search   ");

                //Act
                button.Click();

                window.Close();
            }
        }

        [TestMethod]
        public void HtmlButton_HiddenByStyle_ControlExistsAndCanAssertOnStyle()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <button id=""buttonId"" style=""display: none;"" >Hidden</button>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                //Act
                EnhancedHtmlButton button = window.Get<EnhancedHtmlButton>("id=buttonId");

                //Assert
                Assert.IsTrue(button.Exists);

                Assert.IsTrue(button.UnWrap().ControlDefinition.Contains("style=\"display: none;\""));

                window.Close();
            }
        }

        [TestMethod]
        public void HtmlUnorderedList_WithListItems_CanAssertOnListItems()
        {
            WebPage bWin = WebPage.Launch(CurrentDirectory + "/TestHtmlPage.html", "A Test");

            EnhancedHtmlUnorderedList list = bWin.Get<EnhancedHtmlUnorderedList>("id=unorderedList");

            List<EnhancedHtmlListItem> children = (from i in list.GetChildren()
                                                 select i as EnhancedHtmlListItem).ToList();
            Assert.AreEqual(3, children.Count());

            Assert.AreEqual(1, children.Count(x => x.InnerText == "List Item 1"));
            Assert.AreEqual(1, children.Count(x => x.InnerText == "List Item 2"));
            Assert.AreEqual(1, children.Count(x => x.InnerText == "List Item 3"));

            bWin.Close();
        }

        [TestMethod]
        public void HtmlUnorderedListInObjectRepository_WithListItems_CanAssertOnListItems()
        {
            TestHtmlPage bWin = WebPage.Launch<TestHtmlPage>(CurrentDirectory + "/TestHtmlPage.html");

            List<EnhancedHtmlListItem> children = (from i in bWin.list.GetChildren()
                                                 select i as EnhancedHtmlListItem).ToList();
            Assert.AreEqual(3, children.Count());

            Assert.AreEqual(1, children.Count(x => x.InnerText == "List Item 1"));
            Assert.AreEqual(1, children.Count(x => x.InnerText == "List Item 2"));
            Assert.AreEqual(1, children.Count(x => x.InnerText == "List Item 3"));

            bWin.Close();
        }

        [TestMethod]
        public void HtmlCheckBox_DisabledByStyle_ControlExistsAndCanGetCheckedState()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <input type=""checkbox"" id=""checkBoxId"" disabled=""disabled"" name=""checkBoxName"" checked=""checked"" />
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                //Act
                EnhancedHtmlCheckBox checkBox = window.Get<EnhancedHtmlCheckBox>("id=checkBoxId");

                //Assert
                Assert.IsTrue(checkBox.Exists);
                Assert.IsTrue(checkBox.Checked);

                window.Close();
            }
        }

        [TestMethod]
        public void SelectItem_UsingHtmlComboBoxThatAlertsOnChange_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <select id=""selectId"" onchange=""alert('onchange');"">
            <option>Apple</option>
            <option>Banana</option>
            <option>Carrot</option>
        </select>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlComboBox comboBox = window.Get<EnhancedHtmlComboBox>("Id=selectId");

                //Act
                comboBox.SelectItem("Banana");

                window.PerformDialogAction(BrowserDialogAction.Ok);

                window.Close();
            }
        }

        [TestMethod]
        public void SetText_OnHtmlEdit_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <div id=""div1"">
            <input type=""text""/>
        </div>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");
                EnhancedHtmlDiv div = window.Get<EnhancedHtmlDiv>("id=div1");
                EnhancedHtmlEdit inputTextBox = div.Get<EnhancedHtmlEdit>();

                //Act
                inputTextBox.SetText("text");

                //Assert
                Assert.AreEqual("text", inputTextBox.GetText());

                window.Close();
            }
        }

        [TestMethod]
        public void SetText_OnHtmlEditWithOverlappedDiv_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <div class=""textbox"" id=""idDiv_PWD_UsernameTb"" style=""margin-bottom: 8px;"">
            <div style=""width: 100%; position: relative;"">
                <input name=""login"" id=""i0116"" style=""ime-mode: inactive;"" type=""email"" maxLength=""113""/>
                <div class=""phholder"" style=""left: 0px; top: 0px; width: 100%; position: absolute; z-index: 5;"">
                    <div class=""placeholder"" id=""idDiv_PWD_UsernameExample"" style=""cursor: text;"">
                    Text - someone@example.com
                    </div>
                </div>
            </div>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var bWin = new WebPage("test");
                EnhancedHtmlEdit txtUserName = bWin.Get<EnhancedHtmlEdit>("id=i0116");

                //Act
                txtUserName.SetText("hello");

                //Assert
                Assert.AreEqual("hello", txtUserName.GetText());

                bWin.Close();
            }
        }

        [TestMethod]
        public void SelectedItems_OnHtmlList_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <select id=""selectId"" multiple=""multiple"">
            <option value=""1"">1</option>
            <option value=""2"">2</option>
            <option value=""3"">3</option>
        </select>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var bWin = new WebPage("test");
                EnhancedHtmlList list = bWin.Get<EnhancedHtmlList>("id=selectId");

                var itemsToSelect = new[] {"1", "2"};

                //Act
                list.SelectedItems = itemsToSelect;

                //Assert
                CollectionAssert.AreEqual(itemsToSelect, list.SelectedItems);

                bWin.Close();
            }
        }

        [TestMethod]
        public void Click_OnHtmlInputButtonWithEqualsSignInSearchParameterValue_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <input type=""submit"" value=""="" onclick=""alert('onclick');""/>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlInputButton button = window.Get<EnhancedHtmlInputButton>("Value==");

                //Act
                button.Click();

                window.PerformDialogAction(BrowserDialogAction.Ok);

                window.Close();
            }
        }

        [TestMethod]
        public void InnerText_OnHtmlComboBoxWithDisabledItems_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <select id=""selectId"">
            <option value=""1"">1</option>
            <option value=""2"" disabled=""disabled"">2</option>
            <option value=""3"" disabled=""disabled"">3</option>
        </select>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlComboBox comboBox = window.Get<EnhancedHtmlComboBox>("Id=selectId");

                //Assert
                Assert.AreEqual(3, comboBox.ItemCount);
                CollectionAssert.AreEqual(new[] {"1", "2", "3"}, comboBox.Items);
                Assert.AreEqual("1 2 3 ", comboBox.InnerText);

                window.Close();
            }
        }

        [TestMethod]
        public void LabelFor_OnHtmlLabel_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <form>
          <label for=""male"">Male</label>
          <input type=""radio"" name=""sex"" id=""male"" value=""male""><br>
          <label for=""female"">Female</label>
          <input type=""radio"" name=""sex"" id=""female"" value=""female""><br>
          <label id=""other"" for=""other"">Other</label>
          <input type=""radio"" name=""sex"" id=""other"" value=""other""><br>
          <input type=""submit"" value=""Submit"">
        </form> 
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlLabel label = window.Get<EnhancedHtmlLabel>("id=other");

                //Assert
                Assert.AreEqual("other", label.LabelFor);

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/440347
        /// </summary>
        [TestMethod]
        public void ClickAllControlsOnPage_UsingReflection_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <a href=""#"">test</a>
        <button>test</button>
<input type=""text"" value=""test""/>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                var a = (IEnhancedControlBase) window.Get<EnhancedHtmlHyperlink>("InnerText=test");
                a.Click();

                var list = new List<Type>();
                list.Add(typeof (EnhancedHtmlHyperlink));
                list.Add(typeof (EnhancedHtmlButton));
                list.Add(typeof (EnhancedHtmlEdit));

                MethodInfo getMethodInfo = typeof (WebPage).GetMethod("Get");

                foreach (Type t in list)
                {
                    MethodInfo test = getMethodInfo.MakeGenericMethod(t);

                    IEnhancedControlBase control;

                    if ((t == typeof (EnhancedHtmlEdit)) || (t == typeof (EnhancedHtmlTextArea)))
                    {
                        control = (IEnhancedControlBase) test.Invoke(window, new object[] {"Value=test"});
                    }
                    else
                    {
                        //window.Get<t>("InnerText=test");
                        control = (IEnhancedControlBase) test.Invoke(window, new object[] {"InnerText=test"});
                    }

                    //Act
                    control.Click();

                    if (control is EnhancedHtmlEdit)
                    {
                        (control as EnhancedHtmlEdit).SetText("text");
                    }
                    else if (control is EnhancedHtmlTextArea)
                    {
                        (control as EnhancedHtmlTextArea).SetText("text");
                    }
                }

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/440720
        /// </summary>
        [TestMethod]
        public void SetText_UsingControlsDefinedInObjectRepositoryHierarchy_Succeeds()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <div id=""div1"" >
            <div id=""div2"" >
                <input type=""text"" id=""edit""/>
            </div>
        </div>
    </body>
</html>"))
            {
                HtmlTestPage window = WebPage.Launch<HtmlTestPage>(tempFile.FilePath);

                //Act
                window.div1.div2.edit.SetText("test");

                //Assert
                Assert.IsTrue(window.div1.div2.edit.Exists);
                Assert.IsTrue(window.div1.div2.Exists);
                Assert.IsTrue(window.div1.Exists);

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/440922
        /// </summary>
        [TestMethod]
        public void GetChildren_UsingHyperlinks_CanFindHyperlinkByInnerText()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <div id=""div1"">
            <a href=""#"">A - B - C</a>
            <a href=""#"">A - F - E</a>
            <a href=""#"">A - D - E</a>
            <a href=""#"">Z - B - C</a>
            <a href=""#"">Z - D - E</a>
        </div>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                //Act
                var collection = window.Get<EnhancedHtmlDiv>("id=div1").GetChildren();
                foreach (var control in collection)
                {
                    if (control is EnhancedHtmlHyperlink)
                    {
                        var link = (EnhancedHtmlHyperlink) control;
                        if (link.InnerText.StartsWith("A"))
                        {
                            Trace.WriteLine(string.Format("found: {0}", link.InnerText));
                        }
                    }
                }

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/440742
        /// </summary>
        [TestMethod]
        public void Launch_UsingNewInstanceOfABrowserWindow_CanUsePartialWindowTitle()
        {
            //Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test 1 2 3</title>
    </head>
    <body>
        <button id=""buttonId"" >Button</button>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                //Act
                EnhancedHtmlButton button = window.Get<EnhancedHtmlButton>("id=buttonId");

                //Assert
                Assert.AreEqual(button.InnerText, "Button");

                Trace.WriteLine(window.Uri.ToString());

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/442631
        /// </summary>
        [TestMethod]
        public void Launch_ObjectRepositoryTempHtmlFile_CanFindUnorderedListsByTagAndClassName()
        {
            // Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <div id=""feed_tabs"" class=""ui-tabs"">
            <ul class=""dataFeedTab ui-tabs-nav"">
                <li data-bind-iterate=""."" class=""ui-tabs-selected ui-state-active"">
                    <a href=""#ui-tabs-1"" data-bind=""createTabLink"" data-bind-type=""function"" class=""JQtab"">Attack Correlation Details</a>
                </li>
                <li data-bind-iterate="""" iterate-limit="""" class="""">
                    <a href=""#ui-tabs-2"" data-bind=""createTabLink"" data-bind-type=""function"" class=""JQtab"">Common Details</a>
                </li>
                <li data-bind-iterate="""" iterate-limit="" class="">
                    <a href=""#ui-tabs-3"" data-bind=""createTabLink"" data-bind-type=""function"" class=""JQtab"">Exposure Details</a>
                </li>
                <li data-bind-iterate="" iterate-limit="" class=""><a href=""#ui-tabs-4"" data-bind=""createTabLink"" data-bind-type=""function"" class=""JQtab"">IP Reputation Feed</a>
                </li>
            </ul>
          </div>
    </body>
</html>"))
            {
                // Act
                HtmlTestPageFeeds window = WebPage.Launch<HtmlTestPageFeeds>(tempFile.FilePath);

                var cus = new HtmlCustom(window.divFeedTabs.UnWrap());
                cus.SearchProperties.Add(HtmlControl.PropertyNames.TagName, "ul", PropertyExpressionOperator.EqualTo);
                cus.SearchProperties.Add(HtmlControl.PropertyNames.Class, "dataFeedTab ui-tabs-nav",
                                         PropertyExpressionOperator.EqualTo);

                Assert.IsTrue(cus.Exists);

                EnhancedHtmlCustom cusDataFeedTabsNav =
                    window.Get<EnhancedHtmlCustom>("Class=dataFeedTab ui-tabs-nav;TagName=ul");
                Assert.IsTrue(cusDataFeedTabsNav.Exists);

                // Assert
                Assert.IsTrue(window.cusDataFeedTabsNav.Exists);
                Assert.IsTrue(window.cusdatafeedtabsnav1.Exists);
                Assert.IsTrue(window.cusDataFeedTabsNav2.Exists);
                Assert.IsTrue(window.cusDataFeedTabsNav3.Exists);

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/443094
        /// </summary>
        [TestMethod]
        public void Launch_TempHtmlFile_CanFindHyperlinkByHref()
        {
            // Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <div class=""login"" style=""border: none;"">
        <div class=""member_box"">
            <span>APPLY FOR MEMBERSHIP</span> <a href=""/registration""> </a>
        </div>
    </body>
</html>"))
            {
                // Act
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                // Assert
                EnhancedHtmlHyperlink SignUpHyperLink = window.Get<EnhancedHtmlHyperlink>("href~registration");
                Assert.IsTrue(SignUpHyperLink.Exists, "SignUp not found");

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/443146
        /// </summary>
        [TestMethod]
        public void Launch_TempHtmlFileWithInputWithMaxLength_CanSetTextWhichExceedsMaxLength()
        {
            // Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <input id=""input"" type=""text"" maxlength=10 />
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                EnhancedHtmlEdit input = window.Get<EnhancedHtmlEdit>("id=input");

                // Act
                string inputText = "12345678901";
                string outputText = "1234567890";
                Keyboard.SendKeys(input.UnWrap(), inputText);

                // Assert
                Assert.AreEqual(input.GetText(), outputText);

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/439644
        /// </summary>
        [TestMethod]
        public void GetHtmlDiv_ByClass_Succeeds()
        {
            // Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <div class=""button""><a href=""/main"">main text</a></div>
        <div class=""button""><a href=""/about"">about text</a></div>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                // Act
                EnhancedHtmlDiv div = window.Get<EnhancedHtmlDiv>("class=button");

                EnhancedHtmlHyperlink about = window.Get<EnhancedHtmlHyperlink>("InnerText=about text;href~about");
                var div2 = about.Parent as EnhancedHtmlDiv;

                // Assert
                Assert.IsTrue(div.Exists);
                Assert.AreEqual("main text", div.UnWrap().InnerText);

                Assert.IsTrue(about.Exists);

                Assert.IsTrue(div2.Exists);
                Assert.AreEqual("about text", div2.UnWrap().InnerText);

                window.Close();
            }
        }

        /// <summary>
        ///     https://cuite.codeplex.com/discussions/443509
        /// </summary>
        [TestMethod]
        public void GetHtmlRow_ById_Succeeds()
        {
            // Arrange
            using (var tempFile = new TempFile(
                @"<html>
    <head>
        <title>test</title>
    </head>
    <body>
        <table class=""cart"" cellspacing=""0"">
          <tbody>
            <tr id=""555002_gp2"">
                <td>
                    banana
                </td>
            </tr>
          </tbody>
        </table>
    </body>
</html>"))
            {
                WebPage.Launch(tempFile.FilePath);
                var window = new WebPage("test");

                // Act
                EnhancedHtmlRow row = window.Get<EnhancedHtmlRow>("id=555002_gp2");

                // Assert
                Assert.IsTrue(row.Exists);

                window.Close();
            }
        }
    }
}