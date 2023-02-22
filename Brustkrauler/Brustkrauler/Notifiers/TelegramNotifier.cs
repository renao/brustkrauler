using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                "@renao2000",
                "Update empfangen",
                Telegram.Bot.Types.Enums.ParseMode.Html);

        }
    }
}
