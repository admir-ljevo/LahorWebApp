using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Izvjestaj
    {
        [Key]
        public int Id { get; set; }
        public string Oznaka { get; set; }

        [ForeignKey(nameof(VrstaIzvjestaja))]
        public int VrstaIzvjestajaId { get; set; }
        public VrstaIzvjestaja VrstaIzvjestaja { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public Uposlenik AutorUposlenik { get; set; }
        public UpravnoOsoblje AutorUpravnoOsoblje { get; set; }
        public IList<IzvjestajiNarudzbe> IzvjestajiNarudzbe { get; set; }
    }
}
