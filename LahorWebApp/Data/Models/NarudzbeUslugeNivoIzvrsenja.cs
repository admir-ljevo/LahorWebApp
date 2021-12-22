using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("NarudzbeUslugeNivoIzvrsenja")]
    public class NarudzbeUslugeNivoIzvrsenja
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Narudzba))]
        public int NarudzbaId { get; set; }
        public Narudzba Narudzba { get; set; }

        [ForeignKey(nameof(Usluga))]
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }

        [ForeignKey(nameof(NivoIzvrsenjaUsluge))]
        public int NivoIzvrsenjaId { get; set; }
        public NivoIzvrsenjaUsluge NivoIzvrsenjaUsluge { get; set; }
        public float Cijena { get; set; }
        public float Kolicina { get; set; }


    }
}
