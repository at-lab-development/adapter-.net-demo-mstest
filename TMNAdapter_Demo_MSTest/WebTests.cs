﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMNAdapter.MSTest.Tracking.Attributes;
using TMNAdapter_Demo_MSTest.Common;
using TMNAdapter.MSTest.Utilities;

namespace TMNAdapter_Demo_MSTest
{
    [TestClass]
    public class WebTests : BaseTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Screenshoter.Initialize(Browser.Instance.GetDriver());
        }

        [JiraTestMethod("EPMFARMATS-2466")]
        public void AlwaysPassedTest()
        {
            YouTubePage page = new YouTubePage("https://www.youtube.com/watch?v=UKKYpdWPSL8");
            string author = page.GetAuthorName();

            JiraInfoProvider.SaveParameter("Author", author);
            JiraInfoProvider.SaveParameter("Title", page.GetVideoTitle());

            Assert.AreEqual(author, "EPAM Systems Global");
        }

        [JiraTestMethod("EPMFARMATS-2470")]
        public void AlwaysFailedTest()
        {
            YouTubePage page = new YouTubePage("https://www.youtube.com/watch?v=sU4i4DTr1HQ");
            string author = page.GetAuthorName();
            string title = page.GetVideoTitle();

            JiraInfoProvider.SaveParameter("Author", author);
            JiraInfoProvider.SaveParameter("Title", title);

            Screenshoter.TakeScreenshot();

            Assert.AreEqual("Atlassian", author);
        }

        [TestCleanup]
        public void Close()
        {
            Screenshoter.Initialize(null);
            Browser.Instance.Quit();
        }
    }
}
