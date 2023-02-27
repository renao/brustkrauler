using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brustkrauler.Crawlers
{
    internal abstract class Crawler
    {
        public abstract string PageUrl { get; }
        
        /// <summary>
        /// The Content to keep track of
        /// </summary>
        /// <returns></returns>
        public abstract string FetchContent();

    }
}
