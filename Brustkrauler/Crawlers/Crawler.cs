using HtmlAgilityPack;

namespace Brustkrauler.Crawlers
{
    internal class Crawler
    {
        public string PageUrl { get; }
        private string ContentXPath { get; }

        public Crawler(string pageUrl, string contentXPath)
        {
            this.PageUrl = pageUrl;
            this.ContentXPath = contentXPath;
        }
        
        /// <summary>
        /// Fetches the content from the provided url via the XPath
        /// </summary>
        /// <returns></returns>
        public virtual string FetchContent()
        {
            var htmlDoc = new HtmlWeb().Load(PageUrl);
            var contentNode = htmlDoc.DocumentNode.SelectSingleNode(ContentXPath);
            return contentNode.InnerHtml;
        }

    }
}
