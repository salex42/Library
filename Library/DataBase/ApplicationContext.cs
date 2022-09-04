using System;
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

            modelBuilder.Entity<Book>().HasData(
                new []
                {
                    new Book
                    {
                        Id = Guid.Parse("c5508b04-e321-4345-aaac-ffc55f981e9c"),
                        Name = "Чистый код. Создание, анализ и рефакторинг",
                        Author = "Роберт Мартин",
                        Count = 1,
                        Article = "123",
                        Year = 2020
                    },
                    new Book
                    {
                        Id = Guid.Parse("9db23f42-f970-4493-96d4-f66ba27454a9"),
                        Name = "Искусство программирования",
                        Author = "Кнут, Дональд Эрвин",
                        Count = 2,
                        Article = "124",
                        Year = 2020
                    },
                    new Book
                    {
                        Id = Guid.Parse("d6b60b8e-3110-4009-bc3a-3aa046e76591"),
                        Name = "Детектив про детектива",
                        Author = "Маринина",
                        Count = 200,
                        Article = "125",
                        Year = 2020,
                        DeleteDateTime = DateTime.Parse("01.01.2000")
                    },
                    new Book
                    {
                        Id = Guid.Parse("0d601e61-1d35-4d5c-8f09-2c674e3d87ba"),
                        Name = "Gangs of Four (GoF) Design Patterns",
                        Author = "Erich Gamma",
                        Count = 1,
                        Article = "126",
                        Year = 2020
                    },
                });

            modelBuilder.Entity<Reader>().HasData(
                new[]
                {
                    new Reader
                    {
                        Id = Guid.Parse("39f7f096-bb97-45ca-91d5-8b53bedc1d56"),
                        Fio = "Иванов И.И.",
                        Birthday = DateTime.Parse("05.05.1990")
                    },
                    new Reader
                    {
                        Id = Guid.Parse("d117ab3b-c26a-4175-8ef9-04943540f4c6"),
                        Fio = "Петров П.П.",
                        Birthday = DateTime.Parse("05.05.1991")
                    }
                });

            modelBuilder.Entity<Register>().HasData(
                new[]
                {
                    new Register
                    {
                        Id = Guid.Parse("03f98c08-4df2-4d91-bec8-731820e85750"),
                        BookId = Guid.Parse("d6b60b8e-3110-4009-bc3a-3aa046e76591"),
                        ReaderId = Guid.Parse("39f7f096-bb97-45ca-91d5-8b53bedc1d56"),
                        TakeDateTime = DateTime.Parse("05.05.2022"),
                        GiveDateTime = DateTime.Parse("05.06.2022")
                    },
                    new Register
                    {
                        Id = Guid.Parse("8b80c57f-327c-4702-85da-3bcdc31513b7"),
                        BookId = Guid.Parse("9db23f42-f970-4493-96d4-f66ba27454a9"),
                        ReaderId = Guid.Parse("39f7f096-bb97-45ca-91d5-8b53bedc1d56"),
                        TakeDateTime = DateTime.Parse("05.05.2022"),
                        GiveDateTime = null
                    },
                    new Register
                    {
                        Id = Guid.Parse("89b9b80f-3ff2-42e7-89ae-36128d2c40b3"),
                        BookId = Guid.Parse("0d601e61-1d35-4d5c-8f09-2c674e3d87ba"),
                        ReaderId = Guid.Parse("d117ab3b-c26a-4175-8ef9-04943540f4c6"),
                        TakeDateTime = DateTime.Parse("05.07.2022"),
                        GiveDateTime = null
                    }
                });
        }
    }
}
