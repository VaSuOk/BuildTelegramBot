using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BuildTelegramBot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void ExecuteAsync(MessageEventArgs e, TelegramBotClient client);
        public bool Contains(string command)
        {
            return command.Contains(this.Name) && command.Contains(AppSettings.Name_Bot);
        }
    }
}
