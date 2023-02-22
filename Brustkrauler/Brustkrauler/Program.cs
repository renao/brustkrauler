using Brustkrauler.Crawlers;
using Brustkrauler.Notifiers;
using Brustkrauler.Store;

var telegramToken = args[0] ?? "";

var store = new LastCrawlContentStore();
var telegram = new TelegramNotifier(telegramToken);

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
        await telegram.SendChangeInfosAsync(crawler.PageUrl);
    }
}

Console.ReadKey();