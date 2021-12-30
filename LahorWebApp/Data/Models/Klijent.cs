using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Data.Models
{
    [Table("Klijenti")]
    public class Klijent
    { 
        [Key]
        public int Id { get; set; }
        public  bool Aktivan { get; set; }
        public bool  ClanskaKartica { get; set; }
        [JsonIgnore]
        public KlijentFizickoLice klijentFizicko => this as KlijentFizickoLice;

        [JsonIgnore]
        public KlijentPravnoLice klijentPravno => this as KlijentPravnoLice;

    }
}
