using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels
{
    public class ObavijestAddVM
    {
        public string Naslov { get; set; }
        public int AutorId { get; set; }
        public string Sadrzaj { get; set; }
        public bool JavnaObavijest { get; set; }

    }
}
