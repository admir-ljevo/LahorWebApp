using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels.Izvjestaj
{
    public class IzvjestajAddVM
    {
        public int VrstaIzvjestajaId { get; set; }
        public int AutorId { get; set; }
        public List<Narudzba> Narudzbe { get; set; }
    }
}
