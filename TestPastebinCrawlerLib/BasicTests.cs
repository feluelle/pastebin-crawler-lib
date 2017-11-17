using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using feluelle.Pastebin.Crawler;
using feluelle.Pastebin.Document;

namespace TestPastebinCrawlerLib
{
    [TestClass]
    public class BasicTests
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void DownloadEntriesTest()
        {
            PastebinCrawler pastebinCrawler = new PastebinCrawler();
            var archive = pastebinCrawler.DownloadArchive();

            PastebinDocument pastebinDocument = new PastebinDocument(archive);
            var entries = pastebinDocument.GetSmallArchive();

            pastebinCrawler.DownloadEntries(entries, afterEach);
        }

        private void afterEach(int index, string data)
        {
            TestContext.WriteLine("{0}: {1}", index, data);
        }
    }
}
