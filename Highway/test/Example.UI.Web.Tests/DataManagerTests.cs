using Highway.Insurance.UI;
using Highway.Insurance.UI.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.UI.Web.Tests
{
    [TestClass]
    public class DataManagerTests
    {
        [TestMethod]
        public void GetDataRow_UsingEmbeddedResourceThatDoesNotExist_ThrowsResourceNotFoundException()
        {
            try
            {
               EnhancedDataManager.GetDataRow(typeof (DataManagerTests), "EmbeddedResourceThatDoesNotExist",
                                                   "DoesNotExist");

                Assert.Fail("ResourceNotFoundException not thrown");
            }
            catch (ResourceNotFoundException)
            {
                //expected; success
            }
        }
    }
}