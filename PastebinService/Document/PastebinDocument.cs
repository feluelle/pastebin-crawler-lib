using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace Pastebin.Service.Document
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

        public IEnumerable<HtmlAttribute> GetArchive()
        {
            return HtmlDocument.DocumentNode
                .SelectSingleNode("//table[@class='maintable']")
                .Descendants("a")
                .Select(a => a.Attributes["href"]);
        }

        public IEnumerable<HtmlAttribute> GetSmallArchive()
        {
            return HtmlDocument.DocumentNode
                .SelectSingleNode("//ul[@class='right_menu']")
                .Descendants("a")
                .Select(a => a.Attributes["href"]);
        }
    }
}
