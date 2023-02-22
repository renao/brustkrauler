using Telegram.Bot;

namespace Brustkrauler.Notifiers
{
    internal class TelegramNotifier
    {
        private TelegramBotClient _bot;

        public TelegramNotifier(string apiToken)
        {
            _bot = new TelegramBotClient(apiToken);
        }

        public async Task SendChangeInfosAsync(string pageUrl)
        {
            await _bot.SendTextMessageAsync(
                85700835L,
                $"Aktualisierung empfangen:" +
                $"{Environment.NewLine}" +
                $"{pageUrl}");
        }
    }
}
