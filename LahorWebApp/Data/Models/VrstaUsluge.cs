using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("VrsteUsluga")]
    public class VrstaUsluge
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
    }
}
