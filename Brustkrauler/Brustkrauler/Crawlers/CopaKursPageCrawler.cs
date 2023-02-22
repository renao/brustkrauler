namespace Brustkrauler.Crawlers
{
    internal class CopaKursPageCrawler : Crawler
    {
        public override string PageUrl
            => "https://service.copacabackum.de/de/bookings/block_list/course_id/10/";

        public override string FetchContent()
        {
            return string.Empty;
        }
    }
}
