using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels.Narudzbe
{
    public class NarudzbeAddVM
    {
        public string Naziv { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public bool Isporucena { get; set; }
        public float Cijena { get; set; }
        public float Kolicina { get; set; }
        public string Opis { get; set; }
        public int AutorId { get; set; }
        public int KlijentId { get; set; }
        public List<UslugeNivoIzvrsenja> UslugeNivoIzvrsenja { get; set; }
    }
}
