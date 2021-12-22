using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Usluge")]
    public class Usluga
    {
        [Key]
        public int Id { get; set; }
        public string NazivUsluge { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumModifikovanja { get; set; }
        //public float CijenaPranje { get; set; }
        //public float CijenaSusenje { get; set; }
        //public float CijenaPeglanje { get; set; }
        //public float CijenaPranjeSusenje { get; set; }
        //public float CijenaSusenjePeglanje { get; set; }
        //public float CijenaPranjeSusenjePeglanje { get; set; }

        [ForeignKey(nameof(VrstaUsluge))]
        public int VrstaUslugeId { get; set; }
        public VrstaUsluge VrstaUsluge { get; set; }
    }
}
