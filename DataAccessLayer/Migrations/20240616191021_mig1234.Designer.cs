﻿// <auto-generated />
using System;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240616191021_mig1234")]
    partial class mig1234
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryGame", b =>
                {
                    b.Property<int>("CategoriesCategoryID")
                        .HasColumnType("int");

                    b.Property<int>("GamesGameID")
                        .HasColumnType("int");

                    b.HasKey("CategoriesCategoryID", "GamesGameID");

                    b.HasIndex("GamesGameID");

                    b.ToTable("CategoryGame");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyID"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameID"), 1L, 1);

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GameID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("EntityLayer.Concrete.GameCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "GameID");

                    b.HasIndex("GameID");

                    b.ToTable("GameCategory");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Platform", b =>
                {
                    b.Property<int>("PlatformID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatformID"), 1L, 1);

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlatformID");

                    b.ToTable("Platforms");
                });

            modelBuilder.Entity("EntityLayer.Concrete.PlatformGame", b =>
                {
                    b.Property<int>("PlatformID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("PlatformID", "GameID");

                    b.HasIndex("GameID");

                    b.ToTable("PlatformGame");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Test1", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Test1s");
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.Property<int>("GamesGameID")
                        .HasColumnType("int");

                    b.Property<int>("PlatformsPlatformID")
                        .HasColumnType("int");

                    b.HasKey("GamesGameID", "PlatformsPlatformID");

                    b.HasIndex("PlatformsPlatformID");

                    b.ToTable("GamePlatform");
                });

            modelBuilder.Entity("CategoryGame", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.Game", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Company", "Company")
                        .WithMany("Games")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("EntityLayer.Concrete.GameCategory", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("EntityLayer.Concrete.PlatformGame", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Platform", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesGameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsPlatformID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.Company", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
