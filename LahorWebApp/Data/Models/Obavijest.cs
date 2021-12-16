using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Obavještenja")]
    public class Obavijest
    {
        [Key]
        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime DatumKreiranja { get; set; }

        [ForeignKey(nameof(Autor))]
        public int AutorId { get; set; }
        public UpravnoOsoblje Autor { get; set; }
        public string SlikaObavještenja { get; set; }
        public string Sadrzaj { get; set; }
        public bool JavnaObavijest { get; set; }
    }
}
