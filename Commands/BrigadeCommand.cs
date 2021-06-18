using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BuildTelegramBot.Commands
{
    class BrigadeCommand : Command
    {
        public override string Name => "Бригада";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e?.Message.Chat.Id;
            var messageId = e.Message.MessageId;

            client.SendTextMessageAsync(e.Message.Chat, "🛠", replyMarkup: Buttons.GetBrigadeButtons());
        }
    }
}
