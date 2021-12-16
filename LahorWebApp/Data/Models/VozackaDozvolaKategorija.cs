﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("VozackaDozvolaKategorija")]
    public class VozackaDozvolaKategorija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}