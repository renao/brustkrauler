using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brustkrauler.Crawlers
{
    internal class SchwimmkursePageCrawler : Crawler
    {
        public override string PageUrl
            => "https://www.copacabackum.de/schwimmbad/kursangebote/schwimmkurse.html";

        public override string FetchContent()
        {
            return string.Empty;
        }
    }
}
