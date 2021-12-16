using System;
using System.Collections.Generic;
using EF.Model;

namespace EF.App
{
    public static class Cli
    {
        private static void S(string message, ConsoleColor color, Action<string> action)
        {
            Console.ForegroundColor = color;
            action.Invoke(message);
            Console.ResetColor();
        }
        private static void Show(string message, ConsoleColor color)
        {
            S(message, color, Console.Write);
        }
        private static void ShowL(string message, ConsoleColor color)
        {
            S(message, color, Console.WriteLine);
        }
        
        public static void ShowInfo(string message)
        {
            ShowL(message, ConsoleColor.Blue);
        }
        public static void ShowError(string message)
        {
            ShowL(message, ConsoleColor.Red);
        }

        public static string Input(string message)
        {
            Show(message, ConsoleColor.DarkBlue);
            return Console.ReadLine();
        }

        public static void ShowAll(List<Author> list)
        {
            ShowL("*** Список авторов ***", ConsoleColor.Yellow);
            foreach (var author in list)
            {
                ShowL($"{author.Id}: {author.LastName} {author.FirstName}", ConsoleColor.Yellow);
            }
            ShowL("*** *** ***", ConsoleColor.Yellow);
        }

        private static Dictionary<string, string> _menu = new()
        {
            { "1", "Добавление" },
            { "2", "Обновление" },
            { "3", "Удаление" },
            { "4", "Показать всех" },
            { "0", "Выход" }
        };

        public static void ShowMenu()
        {
            ShowL("*** Список действий ***", ConsoleColor.Green);
            foreach (var (key, value) in _menu)
            {
                ShowL($"{key} -> {value}", ConsoleColor.Green);
            }
        }
    }
}