﻿using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BuildTelegramBot.Commands
{
    class BackCommand : Command
    {
        public override string Name => "Повернутись назад";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            client.SendTextMessageAsync(e.Message.Chat, "Головне меню", replyMarkup: Buttons.GetMainButtons());
        }
    }
}
