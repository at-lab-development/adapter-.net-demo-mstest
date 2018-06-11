using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMNAdapter.Core.Common;
using TMNAdapter.MSTest.Tracking;
using TMNAdapter.MSTest.Utilities;

namespace TMNAdapter_Demo_MSTest
{
    [TestClass]
    public class BaseTest
    {
        protected static JiraInfoProvider JiraInfoProvider { get; set; }
        protected static Screenshoter Screenshoter { get; set; }

        [AssemblyInitialize]
        public static void AssemblyOneTimeSetUp(TestContext testContext)
        {
            JiraInfoProvider = new JiraInfoProvider(testContext);
            Screenshoter = new Screenshoter(testContext);
        }

        [AssemblyCleanup]
        public static void AssemblyOneTimeCleanup()
        {
            TestReporter.GenerateTestResultXml();
        }
    }
}
