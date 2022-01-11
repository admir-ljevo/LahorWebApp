using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels.Izvjestaj
{
    public class IzvjestajGetVM
    {
        public string Oznaka { get; set; }
        public int VrstaIzvjestajaId { get; set; }
        public string NazivVrsteIzvjestaja { get; set; }
        public string DatumKreiranja { get; set; }
        public int AutorId { get; set; }
        public string AutorNaziv { get; set; }

    }
}
