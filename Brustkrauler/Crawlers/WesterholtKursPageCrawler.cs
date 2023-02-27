using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Brustkrauler.Crawlers
{
    internal class WesterholtKursPageCrawler : Crawler
    {
        public override string PageUrl 
            => "https://service.copacabackum.de/de/bookings/block_list/course_id/22/";

        public override string FetchContent()
        {
            var htmlDoc = new HtmlWeb().Load(PageUrl);
            // Alternativ: tbody nur für die Ergebnisse
            var contentNode = htmlDoc.DocumentNode.SelectSingleNode("//form[@id='form_bookings-block_list_table']");
            return contentNode.InnerHtml;
        }
    }
}
