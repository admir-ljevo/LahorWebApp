﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("BracniStatusi")]
    public class BracniStatus
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}
