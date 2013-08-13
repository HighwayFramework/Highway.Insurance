using Example.UI.Web.Tests.ObjectRepository;
using Highway.Insurance.UI.Web.Controls.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.UI.Web.Tests
{
    [TestClass]
    public class JquerySelectorTests
    {
        [TestMethod]
        public void ShouldInjectJqueryToPage()
        {
            //Arrange
            var noJquery = WebPage.Launch<NoJquery>("https://rawgithub.com/HighwayFramework/Highway.Insurance/master/Highway/test/Example.UI.Web.Tests/TestHtml/NoJqueryExamples.html");

            //Act
            Assert.IsTrue(noJquery.FirstListItem.CurrentlyExists());

            //Assert
            WebPage.CloseAllBrowsers();
        }
    }
}