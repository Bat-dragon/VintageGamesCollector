using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VintageGamesCollector.Models
{
    public class GameFull
    {
        public int GameId { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Type")]
        public string Type { get; set; }
        [DisplayName("Platform")]
        public string Platform { get; set; }
        [DisplayName("Version")]
        public string Version { get; set; }
        [DisplayName("Manufacturer")]
        public string Manufacturer { get; set; }
        [DisplayName("Grade")]
        public string Grade { get; set; }
        [DisplayName("Image")]
        public byte[] GameImage { get; set; }
        [DisplayName("Last played")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime LastPlayed { get; set; }
        [DisplayName("Level")]
        public string PlayedLevel { get; set; }
        //test !!!
        public byte[] imageBuffer;
    }
}