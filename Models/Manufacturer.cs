using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//
// Copyright 2021 by Jimmy Dahl Pedersen
//

namespace VintageGamesCollector.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerUrl { get; set; }
        public int YearCreated { get; set; }
        public bool Exist { get; set; }
    }
}