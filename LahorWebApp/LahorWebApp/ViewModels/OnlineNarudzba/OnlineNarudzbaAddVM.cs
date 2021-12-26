﻿using Data.Models;
using LahorWebApp.ViewModels.OnlineNarudzba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.ViewModels.OnlineNarudzbaKlijentFizicko
{
    public class OnlineNarudzbaAddVM
    {
        public int KlijentId { get; set; }
        //public string Naziv { get; set; }
        //public DateTime DatumKreiranja { get; set; }
        public DateTime DatumIsporuke { get; set; }
        //public float Cijena { get; set; }
        //public float Kolicina { get; set; }       
        public string Opis { get; set; }
        public List<UslugeNivoIzvrsenjaAddVM> UslugeNivoIzvrsenja  { get; set; }
    }
}
