using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brustkrauler.Crawlers
{
    internal class WesterholtKursPageCrawler : Crawler
    {
        public override string PageUrl 
            => "https://service.copacabackum.de/de/bookings/block_list/course_id/22/";

        public override string FetchContent()
        {
            return string.Empty;
        }
    }
}
