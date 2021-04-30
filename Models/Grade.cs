using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Number")]
        public string GradeNumber { get; set; }
        [DisplayName("Grade text")]
        public string GradeText { get; set; }
    }
}