﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VintageGamesCollector.Models;

namespace VintageGamesCollector.Migrations
{
    [DbContext(typeof(GamesDBContext))]
    partial class GamesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VintageGamesCollector.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("GameImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastPlayed")
                        .HasColumnType("datetime2");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("PlayedLevel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            GameName = "Leisure suit Larry 1",
                            GameTypeId = 1,
                            GradeId = 1,
                            LastPlayed = new DateTime(2021, 4, 28, 10, 2, 41, 997, DateTimeKind.Local).AddTicks(7687),
                            ManufacturerId = 2,
                            PlatformId = 4,
                            PlayedLevel = "Beginner"
                        },
                        new
                        {
                            GameId = 2,
                            GameName = "Civilization 5",
                            GameTypeId = 3,
                            GradeId = 1,
                            LastPlayed = new DateTime(2021, 4, 28, 10, 2, 42, 3, DateTimeKind.Local).AddTicks(5107),
                            ManufacturerId = 3,
                            PlatformId = 3,
                            PlayedLevel = "Expert"
                        },
                        new
                        {
                            GameId = 3,
                            GameName = "X-com: Terror from the deep",
                            GameTypeId = 3,
                            GradeId = 1,
                            LastPlayed = new DateTime(2021, 4, 28, 10, 2, 42, 3, DateTimeKind.Local).AddTicks(5246),
                            ManufacturerId = 4,
                            PlatformId = 1,
                            PlayedLevel = "Expert"
                        });
                });

            modelBuilder.Entity("VintageGamesCollector.Models.GamePlatform", b =>
                {
                    b.Property<int>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlatformName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlatformVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlatformId");

                    b.ToTable("GamePlatforms");

                    b.HasData(
                        new
                        {
                            PlatformId = 1,
                            PlatformName = "Windows",
                            PlatformVersion = "3.1"
                        },
                        new
                        {
                            PlatformId = 2,
                            PlatformName = "Windows",
                            PlatformVersion = "XP"
                        },
                        new
                        {
                            PlatformId = 3,
                            PlatformName = "Windows",
                            PlatformVersion = "10"
                        },
                        new
                        {
                            PlatformId = 4,
                            PlatformName = "Dos",
                            PlatformVersion = "7.1"
                        });
                });

            modelBuilder.Entity("VintageGamesCollector.Models.GameType", b =>
                {
                    b.Property<int>("GameTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GameTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameTypeId");

                    b.ToTable("GameTypes");

                    b.HasData(
                        new
                        {
                            GameTypeId = 1,
                            GameTypeName = "Adventure game"
                        },
                        new
                        {
                            GameTypeId = 2,
                            GameTypeName = "FPS - First person shooter"
                        },
                        new
                        {
                            GameTypeId = 3,
                            GameTypeName = "Strategy"
                        },
                        new
                        {
                            GameTypeId = 4,
                            GameTypeName = "Worldbuilder"
                        });
                });

            modelBuilder.Entity("VintageGamesCollector.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GradeText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            GradeId = 1,
                            GradeNumber = "01",
                            GradeText = "Superb"
                        },
                        new
                        {
                            GradeId = 2,
                            GradeNumber = "02",
                            GradeText = "Good"
                        },
                        new
                        {
                            GradeId = 3,
                            GradeNumber = "03",
                            GradeText = "Bad"
                        });
                });

            modelBuilder.Entity("VintageGamesCollector.Models.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Exist")
                        .HasColumnType("bit");

                    b.Property<string>("ManufacturerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearCreated")
                        .HasColumnType("int");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            ManufacturerId = 1,
                            Exist = false,
                            ManufacturerName = "Microids",
                            YearCreated = 0
                        },
                        new
                        {
                            ManufacturerId = 2,
                            Exist = false,
                            ManufacturerName = "Sierra",
                            YearCreated = 0
                        },
                        new
                        {
                            ManufacturerId = 3,
                            Exist = false,
                            ManufacturerName = "Sid Meier",
                            YearCreated = 0
                        },
                        new
                        {
                            ManufacturerId = 4,
                            Exist = false,
                            ManufacturerName = "Microprose",
                            YearCreated = 0
                        },
                        new
                        {
                            ManufacturerId = 5,
                            Exist = false,
                            ManufacturerName = "Blizzard",
                            YearCreated = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
