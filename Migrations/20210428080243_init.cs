using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VintageGamesCollector.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameTypeId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    GameImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    LastPlayed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayedLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "GameTypes",
                columns: table => new
                {
                    GameTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypes", x => x.GameTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearCreated = table.Column<int>(type: "int", nullable: false),
                    Exist = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.InsertData(
                table: "GamePlatforms",
                columns: new[] { "PlatformId", "PlatformName", "PlatformVersion" },
                values: new object[,]
                {
                    { 1, "Windows", "3.1" },
                    { 2, "Windows", "XP" },
                    { 3, "Windows", "10" },
                    { 4, "Dos", "7.1" }
                });

            migrationBuilder.InsertData(
                table: "GameTypes",
                columns: new[] { "GameTypeId", "GameTypeName" },
                values: new object[,]
                {
                    { 3, "Strategy" },
                    { 4, "Worldbuilder" },
                    { 2, "FPS - First person shooter" },
                    { 1, "Adventure game" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "GameImage", "GameName", "GameTypeId", "GradeId", "LastPlayed", "ManufacturerId", "PlatformId", "PlayedLevel" },
                values: new object[,]
                {
                    { 1, null, "Leisure suit Larry 1", 1, 1, new DateTime(2021, 4, 28, 10, 2, 41, 997, DateTimeKind.Local).AddTicks(7687), 2, 4, "Beginner" },
                    { 2, null, "Civilization 5", 3, 1, new DateTime(2021, 4, 28, 10, 2, 42, 3, DateTimeKind.Local).AddTicks(5107), 3, 3, "Expert" },
                    { 3, null, "X-com: Terror from the deep", 3, 1, new DateTime(2021, 4, 28, 10, 2, 42, 3, DateTimeKind.Local).AddTicks(5246), 4, 1, "Expert" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeNumber", "GradeText" },
                values: new object[,]
                {
                    { 1, "01", "Superb" },
                    { 2, "02", "Good" },
                    { 3, "03", "Bad" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Exist", "ManufacturerName", "ManufacturerUrl", "YearCreated" },
                values: new object[,]
                {
                    { 4, false, "Microprose", null, 0 },
                    { 1, false, "Microids", null, 0 },
                    { 2, false, "Sierra", null, 0 },
                    { 3, false, "Sid Meier", null, 0 },
                    { 5, false, "Blizzard", null, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlatforms");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameTypes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
