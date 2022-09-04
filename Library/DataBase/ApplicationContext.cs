using Microsoft.EntityFrameworkCore;
using Library.Models;
using Library.Models.Library;

namespace Library.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Reader> Readers { get; set; }

        public DbSet<Register> Registers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>()
                .HasOne(register => register.Book)
                .WithMany(book => book.Registers)
                .HasForeignKey(register => register.BookId);

            modelBuilder.Entity<Register>()
                .HasOne(register => register.Reader)
                .WithMany(reader => reader.Registers)
                .HasForeignKey(register => register.ReaderId);
        }
    }
}
