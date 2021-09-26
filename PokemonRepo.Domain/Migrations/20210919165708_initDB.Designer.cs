﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonRepo.Domain;

namespace PokemonRepo.Domain.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210919165708_initDB")]
    partial class initDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PokemonRepo.DTO.Move", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("PokemonRepo.DTO.Pokedex", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Pokedexes");
                });

            modelBuilder.Entity("PokemonRepo.DTO.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AttackPower")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<Guid?>("MoveId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PokedexId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MoveId");

                    b.HasIndex("PokedexId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonRepo.DTO.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PokedexId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokedexId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PokemonRepo.DTO.Pokemon", b =>
                {
                    b.HasOne("PokemonRepo.DTO.Move", "Move")
                        .WithMany()
                        .HasForeignKey("MoveId");

                    b.HasOne("PokemonRepo.DTO.Pokedex", null)
                        .WithMany("Pokemons")
                        .HasForeignKey("PokedexId");

                    b.Navigation("Move");
                });

            modelBuilder.Entity("PokemonRepo.DTO.User", b =>
                {
                    b.HasOne("PokemonRepo.DTO.Pokedex", "Pokedex")
                        .WithMany()
                        .HasForeignKey("PokedexId");

                    b.Navigation("Pokedex");
                });

            modelBuilder.Entity("PokemonRepo.DTO.Pokedex", b =>
                {
                    b.Navigation("Pokemons");
                });
#pragma warning restore 612, 618
        }
    }
}
