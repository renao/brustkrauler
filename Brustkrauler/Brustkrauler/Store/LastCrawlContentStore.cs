namespace Brustkrauler.Store
{
    internal class LastCrawlContentStore
    {

        private string _basePath;
        public LastCrawlContentStore(string basePath)
        {
            _basePath = basePath;
        }
        
        public bool StoreWhenSomethingChanged(string crawlersName, string content)
        {
            var contentFile = Path.Combine(_basePath, FileName(crawlersName));
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