using System.Collections.Immutable;
using Brustkrauler.Crawlers;
using Brustkrauler.Notifiers;
using Brustkrauler.Store;

var scriptPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
var botConfigPath = Path.Combine(
    scriptPath,
    "TelegramBotToken.txt");
if (!File.Exists(botConfigPath))
{
    Console.WriteLine($"ERROR: Missing TelegramBotToken.txt with Telegram Bot Access Token at {botConfigPath}");
    return 2;
}

var subscribersPath = Path.Combine(
    scriptPath,
    "Subscribers.txt");
if (!File.Exists(subscribersPath))
{
    Console.WriteLine($"ERROR: Missing Subscribers.txt with Telegram Chat IDs at {subscribersPath}");
    return 2;
}

var telegramBotToken = File.ReadAllText(botConfigPath);
var subscriberChatIds = File.ReadLines(subscribersPath).Select(long.Parse).ToArray();
var store = new LastCrawlContentStore(scriptPath);
var telegram = new TelegramNotifier(telegramBotToken, subscriberChatIds);

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
    else
    {
        Console.WriteLine($"[{DateTime.Now}] No changes on {crawler.PageUrl}");
    }
}

return 0;