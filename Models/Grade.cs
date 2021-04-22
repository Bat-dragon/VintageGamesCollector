using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//
// Copyright 2021 by Jimmy Dahl Pedersen
//

namespace VintageGamesCollector.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int GradeNumber { get; set; }
        public string GradeText { get; set; }
    }
}