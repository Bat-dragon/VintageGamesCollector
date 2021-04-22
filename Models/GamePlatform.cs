using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//
// Copyright 2021 by Jimmy Dahl Pedersen
//

namespace VintageGamesCollector.Models
{
    public class GamePlatform
    {
        [Key]
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }
        public string PlatformVersion { get; set; }

    }
}