using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Highway.Insurance.UI.Windows
{
    public abstract class CodedUITestBase<T> where T : ICodedUIApplication, new()
    {
        protected T Application { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            Application = new T();
            Application.Start();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (Application != null)
                Application.Close();
        }
    }
}