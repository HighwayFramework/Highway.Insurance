using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using ExampleTest.PageRepository;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace ExampleTest
{
    /// <summary>
    /// Summary description for SyntaskExample
    /// </summary>
    [CodedUITest]
    public class SyntaskExample
    {
        public SyntaskExample()
        {
        }

        [TestMethod]
        public void CurrentUsage()
        {
            var homePage = new HomePage();

        }

        [TestMethod]
        public void WantedUsage()
        {
            var homePage = new HomePage();

        }


        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
