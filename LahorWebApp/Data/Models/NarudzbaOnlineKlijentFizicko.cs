using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("OnlineNarduzbeKlijentiFizickoLice")]
    public class NarudzbaOnlineKlijentFizicko
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(KlijentFizickoLice))]
        public int KlijentFizickoLiceId { get; set; }
        public KlijentFizickoLice KlijentFizickoLice { get; set; }
    }
}
