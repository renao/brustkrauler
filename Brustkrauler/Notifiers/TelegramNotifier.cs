using Brustkrauler.Config;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

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

        public async Task SendChangeInfosAsync(PageConfig page)
        {
            foreach (var chatId in _subscriberChatIds)
            {
                await _bot.SendTextMessageAsync(
                    chatId,
                    $"<strong>Änderung festgestellt</strong>" +
                    $"{Environment.NewLine}" +
                    $"{Environment.NewLine}" +
                    $"{page.Name}" +
                    $"{Environment.NewLine}" +
                    $"{Environment.NewLine}" +
                    $"{page.Url}",
                    ParseMode.Html);
            }
        }
    }
}
