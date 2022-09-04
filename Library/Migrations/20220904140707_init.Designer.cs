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
    [Migration("20220904140707_init")]
    partial class init
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
