using BuildTelegramBot.User;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BuildTelegramBot.Commands
{
    class StartCommand : Command
    {
        public override string Name => "start";


        public override void ExecuteAsync(MessageEventArgs e, TelegramBotClient client)
        {
            var chatId = e?.Message.Chat.Id;
            var messageId = e.Message.MessageId;
            // логіка бота по цій командні має бути тут!
            string message = "Привіт, я будівельний бот-помічник.🤖 \nДопомагатиму тобі в роботі";
            client.SendTextMessageAsync(chatId, message); 
            client.SendTextMessageAsync(chatId, "Обери зручний спосіб авторизації 🔒", replyMarkup: Buttons.GetLoginButtons());
            ListUsers.Get_instance().ChangeStatus(chatId.ToString(), Status.Default);
        }
    }
}
