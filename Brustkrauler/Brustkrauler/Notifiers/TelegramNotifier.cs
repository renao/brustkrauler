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

        public async Task SendChangeInfos(string pageUrl)
        {
            await _bot.SendTextMessageAsync(
                "@renao",
                "Update empfangen",
                Telegram.Bot.Types.Enums.ParseMode.Html);

        }
    }
}
