using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels.Narudzbe
{
    public class NarudzbeGetVM
    {
        public int Id { get; set; }
        public string Oznaka { get; set; }
        public string DatumNarudzbe { get; set; }
        public string DatumIsporuke { get; set; }
        public string AutorNaziv { get; set; }
    }
}
