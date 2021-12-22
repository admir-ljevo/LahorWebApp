﻿using Data.Data;
using Data.Enum;
using Data.Models;
using LahorWebApp.ViewModels.NarudzbaGuest;
using LahorWebApp.ViewModels.Narudzbe;
using LahorWebApp.ViewModels.OnlineNarudzbaKlijentFizicko;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NarudzbaController:ControllerBase
    {
        private readonly LahorAppDBContext dBContext;
        public NarudzbaController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost]
        public ResponseModel AddOnlineNarudzba([FromBody] OnlineNarudzbaAddVM model)
        {
            try
            {
                var klijent = PronadjiKlijenta(model.KlijentId);
                if (klijent != null)
                {
                    Narudzba novaNarudzba = new Narudzba
                    {
                        Naziv = model.Naziv,
                        DatumNarudzbe = DateTime.Now.Date,
                        DatumIsporuke = model.DatumIsporuke,
                        UkupnaCijena = model.Cijena,
                        Kolicina = model.Kolicina,
                        Opis = model.Opis,
                        NazivKlijenta="",
                        isOnline=true
                    };

                    if (klijent is KlijentFizickoLice)
                        novaNarudzba.KlijentFizickoLice = klijent as KlijentFizickoLice;
                    else
                        novaNarudzba.KlijentPravnoLice = klijent as KlijentPravnoLice;
                    if (novaNarudzba != null)
                    {
                        dBContext.Add(novaNarudzba);
                        dBContext.SaveChanges();
                        return new ResponseModel(ResponseCode.OK, "Narudžba uspješno dodana.", novaNarudzba);
                    }
                }

                return new ResponseModel(ResponseCode.Error, "Ne postoji klijent", null);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error, "Narudžba nije dodana. " + ex.Message + "  " + ex.InnerException, null);
            }
        }

        [HttpPost]
        public ResponseModel AddNarudzba([FromBody] NarudzbeAddVM model)
        {
            try
            {
                var klijent = PronadjiKlijenta(model.KlijentId);
                var autor = PronadjiAutor(model.AutorId);
                if (klijent != null || autor!=null)
                {
                    Narudzba novaNarudzba = new Narudzba
                    {
                        Naziv = model.Naziv,
                        DatumNarudzbe = DateTime.Now.Date,
                        DatumIsporuke = model.DatumIsporuke,
                        UkupnaCijena = model.Cijena,
                        Kolicina = model.Kolicina,
                        Opis = model.Opis,
                        NazivKlijenta="",
                        isNarudzbaAutor=true
                    };

                    if (klijent is KlijentFizickoLice)
                        novaNarudzba.KlijentFizickoLice = klijent as KlijentFizickoLice;
                    else
                        novaNarudzba.KlijentPravnoLice = klijent as KlijentPravnoLice;

                    if (autor is UpravnoOsoblje)
                    {
                        novaNarudzba.AutorUpravno = autor as UpravnoOsoblje;
                    }
                    else
                    {
                        novaNarudzba.AutorUposlenik = autor as Uposlenik;
                    }
                    if (novaNarudzba != null)
                    {
                        dBContext.Add(novaNarudzba);
                        dBContext.SaveChanges();
                        return new ResponseModel(ResponseCode.OK, "Narudžba uspješno dodana.", novaNarudzba);
                    }
                }

                return new ResponseModel(ResponseCode.Error, "Klijent ili autor nisu pronađeni", null);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error, "Narudžba nije dodana. " + ex.Message + "  " + ex.InnerException, null);
            }
        }

        [HttpPost]
        public ResponseModel AddNarudzbaGuest([FromBody] NarudzbaGuestAddVM model)
        {
            try
            {
                var autor = PronadjiAutor(model.AutorId);
                if (autor != null)
                {
                    Narudzba novaNarudzba = new Narudzba
                    {
                        Naziv = model.Naziv,
                        DatumNarudzbe = DateTime.Now.Date,
                        DatumIsporuke = model.DatumIsporuke,
                        UkupnaCijena = model.Cijena,
                        Kolicina = model.Kolicina,
                        Opis = model.Opis,
                        NazivKlijenta=model.NazivKlijenta,
                        isGuest=true
                    };

                    if (autor is UpravnoOsoblje)
                    {
                        novaNarudzba.AutorUpravno = autor as UpravnoOsoblje;
                    }
                    else
                    {
                        novaNarudzba.AutorUposlenik = autor as Uposlenik;
                    }
                    if (novaNarudzba != null)
                    {
                        dBContext.Add(novaNarudzba);
                        dBContext.SaveChanges();
                        return new ResponseModel(ResponseCode.OK, "Narudžba uspješno dodana.", novaNarudzba);
                    }
                }

                return new ResponseModel(ResponseCode.Error, "Klijent ili autor nisu pronađeni", null);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error, "Narudžba nije dodana. " + ex.Message + "  " + ex.InnerException, null);
            }
        }

        private object PronadjiAutor(int autorId)
        {
            dynamic klijent = dBContext.UpravnoOsoblje.Where(k => k.Id == autorId).FirstOrDefault();
            if (klijent != null)
                return klijent;
            klijent = dBContext.Uposlenici.Where(k => k.Id == autorId).FirstOrDefault();
            return klijent;
        }

        private object PronadjiKlijenta(int klijentId)
        {
            dynamic klijent =dBContext.KlijentiFizickoLice.Where(k => k.Id == klijentId).FirstOrDefault();
            if (klijent != null)
                return klijent;
            klijent = dBContext.KlijentiPravnoLice.Where(k => k.Id == klijentId).FirstOrDefault();
                return klijent;
        }
    }
}
