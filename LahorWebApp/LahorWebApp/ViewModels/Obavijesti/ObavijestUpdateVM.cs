using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels.Obavijesti
{
    public class ObavijestUpdateVM
    {
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public bool JavnaObavijest { get; set; }
    }
}
