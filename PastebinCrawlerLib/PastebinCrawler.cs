using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace feluelle.Pastebin.Crawler
{
    public class PastebinCrawler
    {
        const string PASTEBIN_URL = "http://www.pastebin.com";

        WebClient wc;

        public PastebinCrawler()
        {
            wc = new WebClient();
        }

        public string DownloadArchive()
        {
            return wc.DownloadString(PASTEBIN_URL + "/archive");
        }

        public string DownloadEntry(string entryId)
        {
            return wc.DownloadString(PASTEBIN_URL + "/raw" + entryId);
        }

        public void DownloadEntries(IEnumerable<string> entries, Action<int, string> afterEach)
        {
            for (int i = 0; i < entries.Count(); i++)
                afterEach(i, DownloadEntry(entries.ElementAt(i)));
        }
    }
}
