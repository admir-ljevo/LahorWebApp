using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("OnlineNarudzbeFizickoUsluge")]
    public class OnlineNarudzbeFizickoUsluge
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(NarudzbaOnlineKlijentFizicko))]
        public int NarudzbaOnlineKlijentFizickoId { get; set; }
        public NarudzbaOnlineKlijentFizicko NarudzbaOnlineKlijentFizicko { get; set; }

        [ForeignKey(nameof(Usluga))]
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }

        [ForeignKey(nameof(NivoIzvrsenjaUsluge))]
        public int NivoIzvrsenjaUslugeId { get; set; }
        public NivoIzvrsenjaUsluge NivoIzvrsenjaUsluge { get; set; }
        public float Kolicina { get; set; }
        public float Cijena { get; set; }
        public float JedinicnaCijena{ get; set; }

    }
}
