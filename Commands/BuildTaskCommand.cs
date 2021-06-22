using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BuildTelegramBot.Commands
{
    class BuildTaskCommand : Command
    {
        public override string Name => "Будівництво";

        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            
        }
    }
}
