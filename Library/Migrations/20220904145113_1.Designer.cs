﻿// <auto-generated />
using System;
using Library.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Library.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220904145113_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Library.Models.Library.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Article")
                        .HasColumnType("text");

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c5508b04-e321-4345-aaac-ffc55f981e9c"),
                            Article = "123",
                            Author = "Роберт Мартин",
                            Count = 1,
                            Name = "Чистый код. Создание, анализ и рефакторинг",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("9db23f42-f970-4493-96d4-f66ba27454a9"),
                            Article = "124",
                            Author = "Кнут, Дональд Эрвин",
                            Count = 2,
                            Name = "Искусство программирования",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("d6b60b8e-3110-4009-bc3a-3aa046e76591"),
                            Article = "125",
                            Author = "Маринина",
                            Count = 200,
                            DeleteDateTime = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Детектив про детектива",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("0d601e61-1d35-4d5c-8f09-2c674e3d87ba"),
                            Article = "126",
                            Author = "Erich Gamma",
                            Count = 1,
                            Name = "Gangs of Four (GoF) Design Patterns",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Library.Models.Library.Reader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DeleteDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Fio")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Readers");
                });

            modelBuilder.Entity("Library.Models.Library.Register", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("GiveDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ReaderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("TakeDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("Library.Models.Library.Register", b =>
                {
                    b.HasOne("Library.Models.Library.Book", "Book")
                        .WithMany("Registers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Library.Reader", "Reader")
                        .WithMany("Registers")
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("Library.Models.Library.Book", b =>
                {
                    b.Navigation("Registers");
                });

            modelBuilder.Entity("Library.Models.Library.Reader", b =>
                {
                    b.Navigation("Registers");
                });
#pragma warning restore 612, 618
        }
    }
}