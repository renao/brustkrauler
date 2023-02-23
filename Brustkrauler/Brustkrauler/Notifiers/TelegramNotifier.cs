using Telegram.Bot;

namespace Brustkrauler.Notifiers
{
    internal class TelegramNotifier
    {
        private TelegramBotClient _bot;
        private long[] _subscriberChatIds;

        public TelegramNotifier(string apiToken, long[] subscriberChatIds)
        {
            _bot = new TelegramBotClient(apiToken);
            _subscriberChatIds = subscriberChatIds;
        }

        public async Task SendChangeInfosAsync(string pageUrl)
        {
            foreach (var chatId in _subscriberChatIds)
            {
                await _bot.SendTextMessageAsync(
                    chatId,
                    $"Aktualisierung festgestellt!" +
                    $"{Environment.NewLine}" +
                    $"{pageUrl}");
            }
        }
    }
}
