namespace Brustkrauler.Store
{
    internal class LastCrawlContentStore
    {
        public bool StoreWhenSomethingChanged(string crawlersName, string content)
        {
            var contentFile = FileName(crawlersName);
            var savedContent
                = File.Exists(contentFile)
                ? File.ReadAllText(contentFile)
                : string.Empty;

            if (content != savedContent || !File.Exists(contentFile))
            {
                File.WriteAllText(contentFile, content);
                return true;
            }

            return false;
        }


        private string FileName(string crawler) => $"{crawler}.last";
    }
}