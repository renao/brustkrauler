using Brustkrauler.Crawlers;
using Brustkrauler.Notifiers;
using Brustkrauler.Store;

var telegramToken = ""; //args[0];

var store = new LastCrawlContentStore();
var telegram = new TelegramNotifier(telegramToken);

// await telegram.SendChangeInfos("http://google.com");

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