using Brustkrauler.Crawlers;
using Brustkrauler.Store;

var store = new LastCrawlContentStore();

var pageCrawlers = new List<Crawler>
{
    new SchwimmkursePageCrawler(),
    new CopaKursPageCrawler(),
    new WesterholtKursPageCrawler()
};

foreach (var crawler in pageCrawlers)
{
    var content = crawler.FetchContent();
    var hasChanged = store.StoreWhenSomethingChanged(crawler.GetType().Name, content);

    if (hasChanged)
    {
        Console.WriteLine($"Alarm! {crawler} => Changed!");
        Console.WriteLine($"See Changes => {crawler.PageUrl}");
    }
}