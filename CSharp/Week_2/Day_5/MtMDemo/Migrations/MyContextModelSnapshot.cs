﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MtMDemo.Models;

#nullable disable

namespace MtMDemo.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MtMDemo.Models.KnownMove", b =>
                {
                    b.Property<int>("KnwonMoveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MoveId")
                        .HasColumnType("int");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("KnwonMoveId");

                    b.HasIndex("MoveId");

                    b.HasIndex("PokemonId");

                    b.ToTable("KnownMoves");
                });

            modelBuilder.Entity("MtMDemo.Models.Move", b =>
                {
                    b.Property<int>("MoveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MoveType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MoveId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("MtMDemo.Models.Pokemon", b =>
                {
                    b.Property<int>("PokemonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PokemonId");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("MtMDemo.Models.KnownMove", b =>
                {
                    b.HasOne("MtMDemo.Models.Move", "Move")
                        .WithMany("PokemonWhoKnowMove")
                        .HasForeignKey("MoveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MtMDemo.Models.Pokemon", "Pokemon")
                        .WithMany("MovesKnown")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Move");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("MtMDemo.Models.Move", b =>
                {
                    b.Navigation("PokemonWhoKnowMove");
                });

            modelBuilder.Entity("MtMDemo.Models.Pokemon", b =>
                {
                    b.Navigation("MovesKnown");
                });
#pragma warning restore 612, 618
        }
    }
}
