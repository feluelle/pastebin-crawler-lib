using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace feluelle.Pastebin.Document
{
    public class PastebinDocument
    {
        public HtmlDocument HtmlDocument { get; set; }
        public PastebinDocument(string htmlString)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlString);

            HtmlDocument = doc;
        }

        public IEnumerable<string> GetArchive()
        {
            return findUrlsIn("//table[@class='maintable']");
        }

        public IEnumerable<string> GetSmallArchive()
        {
            return findUrlsIn("//ul[@class='right_menu']");
        }

        private IEnumerable<string> findUrlsIn(string xpath)
        {
            return from aNode in HtmlDocument.DocumentNode
                   .SelectSingleNode(xpath)
                   .Descendants("a")
                   select aNode.Attributes["href"].Value;
        }
    }
}
