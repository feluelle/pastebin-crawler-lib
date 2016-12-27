using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using HtmlAgilityPack;

namespace Pastebin.Service.DocumentDownloader
{
    public static class PastebinDocumentDownloader
    {

        const string PASTEBIN_URL = "http://www.pastebin.com";

        static WebClient wc = new WebClient();

        public static string DownloadArchive()
        {
            return wc.DownloadString(PASTEBIN_URL + "/archive");
        }

        public static string DownloadEntry(HtmlAttribute url)
        {
            return wc.DownloadString(PASTEBIN_URL + "/raw" + url.Value);
        }
        
        public static void DownloadEntries(IEnumerable<HtmlAttribute> urls, Action<int, string> afterEach)
        {
            int counter = 0;
            urls.ToList()
                .ForEach(node => afterEach(++counter, DownloadEntry(node)));
        }
    }
}
