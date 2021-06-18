using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;

namespace BuildTelegramBot
{
    public class Buttons
    {
        public static IReplyMarkup GetLoginButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Логін та пароль 🔑" }, new KeyboardButton { Text = "Номер телефону 📞" } },
                }
            };
        }
        public static IReplyMarkup GetMainButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Бригада" }, new KeyboardButton { Text = "Завдання" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "⚙️Налаштування⚙️" } } 
                }
            };
        }
        public static IReplyMarkup GetBrigadeButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Контакти працівників бригади" }},
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Статистика Бригад" } },
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Повернутись назад👈" } }
                }
            };
        }

        public static IReplyMarkup GetTasksButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Переглянути завдання" }},
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Повернутись назад👈" } }
                }
            };
        }
        public static IReplyMarkup GetSettingButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Змінити логін та пароль" }},
                    new List<KeyboardButton>{ new KeyboardButton { Text = "Повернутись назад👈" } }
                }
            };
        }
    }
}
