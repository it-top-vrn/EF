using System.IO;
using EF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EF.Lib
{
    public sealed class BookStore : DbContext
    {
        public DbSet<Author> TableAuthors { get; set; }

        public BookStore(DbContextOptions<BookStore> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static BookStore Init()
        {
            var builder = new ConfigurationBuilder(); ;
            var connectionString = builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build()
                .GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<BookStore>();
            var options = optionsBuilder.UseMySQL(connectionString).Options;
            return new BookStore(options);
        }
    }
}