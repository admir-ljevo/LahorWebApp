using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Spolovi")]
    public class Spol
    {
        public int Id { get; set; }
        public string naziv { get; set; }
    }
}
