using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BuildTelegramBot.Commands
{
    class Task : Command
    {
        public override string Name => "Завдання";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}
