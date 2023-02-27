using Brustkrauler.Config;
using Brustkrauler.Crawlers;
using Brustkrauler.Notifiers;
using Brustkrauler.Store;
using Newtonsoft.Json;

var scriptPath 
    = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) 
      ?? string.Empty;

var configFilePath = Path.Combine(scriptPath, "crawler.json");

if (!File.Exists(configFilePath))
{
    Console.Error.WriteLine("ERROR: No config file provided");
} 

var configFileContent = File.ReadAllText(configFilePath);
var config = JsonConvert.DeserializeObject<CrawlerConfig>(configFileContent);

var store = new LastCrawlContentStore(scriptPath);
var telegram = new TelegramNotifier(
    config.Telegram.AccessToken,
    config.Telegram.SubscriberChatIds);

foreach (var page in config.Pages)
{
    var crawler = new Crawler(page.Url, page.XPath);
    var content = crawler.FetchContent();
    
    var hasChanged = store.StoreWhenSomethingChanged(page.Name, content);

    if (hasChanged)
    {
        await telegram.SendChangeInfosAsync(page);
    }
    else
    {
        Console.WriteLine($"[{DateTime.Now}] No changes on {page.Name}");
    }
}

return 0;