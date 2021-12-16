using System;
using System.Collections.Generic;
using EF.Lib;
using EF.Lib.CRUD;
using EF.Model;

namespace EF.App
{
    internal static class Program
    {
        private static Dictionary<string, Action> _actions = new()
        {
            {"1", Add},
            {"2", Update},
            {"3", Delete},
            {"4", ShowAll},
            {"0", Exit}
        };

        private static bool _exit = false;
        private static void Main()
        {
            Cli.ShowInfo("*** BookStore ***");

            do
            {
                Cli.ShowMenu();
                var select = Cli.Input("Введите номер действия: ");
                _actions[select].Invoke();
            } while (!_exit);
        }

        private static void Add()
        {
            Cli.ShowInfo("Добавление нового автора");
            using var table = new AuthorsCrud();
            var firstName = Cli.Input("Введите имя автора: ");
            var lastName = Cli.Input("Введите фамилию автора: ");
            table.Add(new Author
            {
                FirstName = firstName, 
                LastName = lastName
            });
        }

        private static void Update()
        {
            //TODO реализовать метод
        }
        private static void Delete()
        {
            Cli.ShowError("Удалять авторов нельзя!");
        }
        
        private static void ShowAll()
        {
            using var table = new AuthorsCrud();
            Cli.ShowAll(table.ReadAll());
        }

        private static void Exit() => _exit = true;
    }
}