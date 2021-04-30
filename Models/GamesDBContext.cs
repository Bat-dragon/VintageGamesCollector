using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VintageGamesCollector.Models
{
    public class GamesDBContext : DbContext
    {

        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = VintageGamesCollector; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Manufacturer;
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
                              { ManufacturerId = 1, ManufacturerName = "Microids" });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
                              { ManufacturerId = 2, ManufacturerName = "Sierra" });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
                              { ManufacturerId = 3, ManufacturerName = "Sid Meier" });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
                              { ManufacturerId = 4, ManufacturerName = "Microprose" });
            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer
                              { ManufacturerId = 5, ManufacturerName = "Blizzard" });


            //seed Grade
            modelBuilder.Entity<Grade>().HasData(new Grade { GradeId = 1, GradeNumber = "01", GradeText = "Superb" });
            modelBuilder.Entity<Grade>().HasData(new Grade { GradeId = 2, GradeNumber = "02", GradeText = "Good" });
            modelBuilder.Entity<Grade>().HasData(new Grade { GradeId = 3, GradeNumber = "03", GradeText = "Bad" });


            //seed gametype
            modelBuilder.Entity<GameType>().HasData(new GameType { GameTypeId = 1, GameTypeName = "Adventure game" });
            modelBuilder.Entity<GameType>().HasData(new GameType { GameTypeId = 2, GameTypeName = "FPS - First person shooter" });
            modelBuilder.Entity<GameType>().HasData(new GameType { GameTypeId = 3, GameTypeName = "Strategy" });
            modelBuilder.Entity<GameType>().HasData(new GameType { GameTypeId = 4, GameTypeName = "Worldbuilder" });


            //seed platform
            modelBuilder.Entity<GamePlatform>().HasData(new GamePlatform
                                { PlatformId = 1, PlatformName = "Windows", PlatformVersion = "3.1" });
            modelBuilder.Entity<GamePlatform>().HasData(new GamePlatform
                                { PlatformId = 2, PlatformName = "Windows", PlatformVersion = "XP" });
            modelBuilder.Entity<GamePlatform>().HasData(new GamePlatform
                                { PlatformId = 3, PlatformName = "Windows", PlatformVersion = "10" });
            modelBuilder.Entity<GamePlatform>().HasData(new GamePlatform
                                { PlatformId = 4, PlatformName = "Dos", PlatformVersion = "7.1" });

            //See games
            modelBuilder.Entity<Game>().HasData(new Game
            {
                GameId = 1,
                GameName = "Leisure suit Larry 1",
                GameTypeId = 1,
                PlayedLevel = "Beginner",
                ManufacturerId = 2,
                PlatformId = 4,
                GradeId = 1,
                LastPlayed = DateTime.Now
            }) ;
            modelBuilder.Entity<Game>().HasData(new Game
            {
                GameId = 2,
                GameName = "Civilization 5",
                GameTypeId = 3,
                PlayedLevel = "Expert",
                ManufacturerId = 3,
                PlatformId = 3,
                GradeId = 1,
                LastPlayed = DateTime.Now
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                GameId = 3,
                GameName = "X-com: Terror from the deep",
                GameTypeId = 3,
                PlayedLevel = "Expert",
                ManufacturerId = 4,
                PlatformId = 1,
                GradeId = 1,
                LastPlayed = DateTime.Now
            });
        }
    }
}