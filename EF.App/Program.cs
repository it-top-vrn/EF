using EF.Lib;
using EF.Model;

namespace EF.App
{
    internal static class Program
    {
        private static void Main()
        {
            var store = BookStore.Init();
            store.TableAuthors.Add(new Author
            {
                FirstName = "Николай",
                LastName = "Гоголь"
            });
            store.SaveChanges();
        }
    }
}