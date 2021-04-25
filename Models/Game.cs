using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VintageGamesCollector.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [DisplayName("Name")]
        public string GameName { get; set; }
        [DisplayName("Type")]
        public int GameTypeId { get; set; }
        [DisplayName("Platform")]
        public int PlatformId { get; set; }
        [DisplayName("Manufacturer")]
        public int ManufacturerId { get; set; }
        [DisplayName("Grade")]
        public int GradeId { get; set; }
        public byte[] GameImage { get; set; }
        [DisplayName("Last played")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LastPlayed { get; set; }
        [DisplayName("Level")]
        public string PlayedLevel { get; set; }
    }
}