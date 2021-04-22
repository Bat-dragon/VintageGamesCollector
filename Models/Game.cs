using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VintageGamesCollector.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public GameType GameType { get; set; }
        public GamePlatform Platform { get; set; }
        public Grade Grade { get; set; }
        public byte[] GameImage { get; set; }
        public DateTime LastPlayed { get; set; }
        public string PlayedLevel { get; set; }
    }
}