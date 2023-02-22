using HtmlAgilityPack;

namespace Brustkrauler.Crawlers
{
    internal class CopaKursPageCrawler : Crawler
    {
        public override string PageUrl
            => "https://service.copacabackum.de/de/bookings/block_list/course_id/10/";

        public override string FetchContent()
        {
            var htmlDoc = new HtmlWeb().Load(PageUrl);
            var contentNode = htmlDoc.DocumentNode.SelectSingleNode("//form[@id='form_bookings-block_list_table']");
            return contentNode.InnerHtml;
        }
    }
}
