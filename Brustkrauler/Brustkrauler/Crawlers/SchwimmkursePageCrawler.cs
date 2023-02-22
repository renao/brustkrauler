using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Brustkrauler.Crawlers
{
    internal class SchwimmkursePageCrawler : Crawler
    {
        public override string PageUrl
            => "https://www.copacabackum.de/schwimmbad/kursangebote/schwimmkurse.html";

        public override string FetchContent()
        {
            var htmlDoc = new HtmlWeb().Load(PageUrl);
            var contentNode = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='c14883']");
            return contentNode.InnerHtml;
        }
    }
}
