using BuildTelegramBot.Commands;
using BuildTelegramBot.User;
using System;
using System.Collections.Generic;
using System.Net;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BuildTelegramBot
{
    class Program
    {
        
        private static List<Command> commandsList;
        private static TelegramBotClient client;
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        private static void InitCommand()
        {
            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            commandsList.Add(new LoginByPhone());
            commandsList.Add(new LoginByLogAndPass());
            commandsList.Add(new Settings());
            commandsList.Add(new ChangeLoginAndPassword());
            commandsList.Add(new BrigadeCommand());
            commandsList.Add(new ContactsBrigadeCommand());
            commandsList.Add(new BackCommand());
        }

        static void Main(string[] args)
        {
            //безпечне підключення
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            // ініт командс
            InitCommand();

            //конект до бота
            client = new TelegramBotClient(AppSettings.Key) { Timeout = TimeSpan.FromSeconds(10) };
            client.OnMessage += Bot_OnMessage;
            client.StartReceiving(); 
            //Логи
            var me = client.GetMeAsync().Result;
            Console.ReadKey();
        }


        private static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            bool commandFound = false;
            var commands = Commands;
            var message = e;
            var msg = e.Message;
            Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");
            if(msg.Text != null)
            {
                foreach (var command in Commands)
                {
                    if (command.Contains(message?.Message.Text))
                    {                    
                        command.ExecuteAsync(message, client);
                        commandFound = true;
                        return;
                    }
                }
                if (!commandFound)
                {
                    if(ListUsers.Get_instance().IsStatusTrue(message.Message.Chat.Id.ToString(), Status.WaitInputLoginAndPassword))
                    {
                        LoginByLogAndPass.GetLoginData(message, client);
                    }
                    if(ListUsers.Get_instance().IsStatusTrue(message.Message.Chat.Id.ToString(), Status.ChangeDataLogin))
                    {
                        ChangeLoginAndPassword.SetNewLoginData(message, client);
                    }
                }
            }
            else
            {
                if (ListUsers.Get_instance().IsStatusTrue(message.Message.Chat.Id.ToString(), Status.WaitInputPhone))
                {
                    LoginByPhone.GetPhone(message, client);
                }                
            }
            
        }
    }
}
