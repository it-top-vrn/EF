using EF.Model;
using Microsoft.EntityFrameworkCore;

namespace EF.Lib
{
    public sealed class BookStore : DbContext
    {
        public DbSet<Author> TableAuthors { get; set; }

        public BookStore()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=mysql60.hostland.ru;user=host1323541_itstep;password=269f43dc;database=host1323541_vrn07;");
        }
    }
}