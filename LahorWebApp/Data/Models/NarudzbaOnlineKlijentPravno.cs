using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("OnlineNarduzbeKlijentiPravnoLice")]
    public class NarudzbaOnlineKlijentPravno:Narudzba
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(KlijentPravnoLice))]
        public int KlijentPravnoLiceId { get; set; }
        public KlijentPravnoLice KlijentPravnoLice { get; set; }

    }
}
