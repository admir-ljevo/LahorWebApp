using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels.NarudzbaGuest
{
    public class NarudzbaGuestAddVM
    {
        public string Naziv { get; set; }
        public string NazivKlijenta { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public float Cijena { get; set; }
        public float Kolicina { get; set; }
        public string Opis { get; set; }
        public int AutorId { get; set; }
        //public List<UslugeNivoIzvrsenja> UslugeNivoIzvrsenja  { get; set; }
    }
}
