using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{

    public class Narudzba
    {
     
        //public int ID { get; set; }

        public string Naziv { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public bool Isporucena { get; set; }
        public float Cijena { get; set; }
        public float Kolicina { get; set; }
        public string Opis { get; set; }
    }
}
