using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("IzvjestajiNarudzbe")]
    public class IzvjestajiNarudzbe
    {
        [ForeignKey(nameof(Narudzba))]
        public int NarudzbaId { get; set; }
        [JsonIgnore]
        public Narudzba Narudzba { get; set; }

        [ForeignKey(nameof(Izvjestaj))]
        public int IzvjestajId { get; set; }

        [JsonIgnore]
        public Izvjestaj Izvjestaj { get; set; }
    }
}
