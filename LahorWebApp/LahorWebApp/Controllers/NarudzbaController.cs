using Data.Data;
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
    public class NarudzbaController : ControllerBase
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
                //var klijent = PronadjiKlijenta(model.KlijentId);
                //if (klijent != null)
                //{
                    Narudzba novaNarudzba = new Narudzba
                    {
                        Naziv = "N",
                        DatumNarudzbe = DateTime.Now.Date,
                        DatumIsporuke = model.DatumIsporuke,
                        UkupnaCijena = 0,
                        Kolicina = 0,
                        Opis = model.Opis,
                        NazivKlijenta = "",
                        isOnline = true,
                        KlijentId=model.KlijentId,
                        Klijent=dBContext.Klijenti.Find(model.KlijentId)
                    };
                    //if (klijent is KlijentFizickoLice)
                    //    novaNarudzba.KlijentFizickoLice = klijent as KlijentFizickoLice;
                    //else
                    //    novaNarudzba.KlijentPravnoLice = klijent as KlijentPravnoLice;
                    if (novaNarudzba != null)
                    {
                        dBContext.Add(novaNarudzba);
                        dBContext.SaveChanges();
                        foreach (var un in model.UslugeNivoIzvrsenja)
                        {
                            dBContext.Add(new NarudzbeUslugeNivoIzvrsenja
                            {
                                NarudzbaId=novaNarudzba.Id,
                                UslugaId=un.UslugaId,
                                NivoIzvrsenjaId=un.NivoIzvrsenjaId
                            });
                        }
                        dBContext.SaveChanges();
                        return new ResponseModel(ResponseCode.OK, "Narudžba uspješno dodana.", novaNarudzba);
                    }
                //}

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
                //var klijent = PronadjiKlijenta(model.KlijentId);
                //var autor = PronadjiAutor(model.AutorId);
                //if (klijent != null || autor != null)
                //{
                    Narudzba novaNarudzba = new Narudzba
                    {
                        Naziv = model.Naziv,
                        DatumNarudzbe = DateTime.Now.Date,
                        DatumIsporuke = model.DatumIsporuke,
                        UkupnaCijena = model.Cijena,
                        Kolicina = model.Kolicina,
                        Opis = model.Opis,
                        NazivKlijenta = "",
                        isNarudzbaAutor = true,
                        //RadnikId=model.AutorId,
                        Radnik=dBContext.Radnici.Find(model.AutorId),
                        KlijentId=model.KlijentId,
                        Klijent=dBContext.Klijenti.Find(model.KlijentId)
                    };

                    //if (klijent is KlijentFizickoLice)
                    //    novaNarudzba.KlijentFizickoLice = klijent as KlijentFizickoLice;
                    //else
                    //    novaNarudzba.KlijentPravnoLice = klijent as KlijentPravnoLice;

                    //if (autor is UpravnoOsoblje)
                    //{
                    //    novaNarudzba.AutorUpravno = autor as UpravnoOsoblje;
                    //}
                    //else
                    //{
                    //    novaNarudzba.AutorUposlenik = autor as Uposlenik;
                    //}
                    if (novaNarudzba != null)
                    {
                        dBContext.Add(novaNarudzba);
                        dBContext.SaveChanges();
                        return new ResponseModel(ResponseCode.OK, "Narudžba uspješno dodana.", novaNarudzba);
                    }
                //}

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
                //var autor = PronadjiAutor(model.AutorId);
                //if (autor != null)
                //{
                Narudzba novaNarudzba = new Narudzba
                {
                    Naziv = model.Naziv,
                    DatumNarudzbe = DateTime.Now.Date,
                    DatumIsporuke = model.DatumIsporuke,
                    UkupnaCijena = model.Cijena,
                    Kolicina = model.Kolicina,
                    Opis = model.Opis,
                    NazivKlijenta = model.NazivKlijenta,
                    isGuest = true,
                    //RadnikId = model.AutorId,
                    Radnik = dBContext.Radnici.Find(model.AutorId)
                    };

                    //if (autor is UpravnoOsoblje)
                    //{
                    //    novaNarudzba.AutorUpravno = autor as UpravnoOsoblje;
                    //}
                    //else
                    //{
                    //    novaNarudzba.AutorUposlenik = autor as Uposlenik;
                    //}
                    if (novaNarudzba != null)
                    {
                        dBContext.Add(novaNarudzba);
                        dBContext.SaveChanges();
                        return new ResponseModel(ResponseCode.OK, "Narudžba uspješno dodana.", novaNarudzba);
                    }
                //}

                return new ResponseModel(ResponseCode.Error, "Klijent ili autor nisu pronađeni", null);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error, "Narudžba nije dodana. " + ex.Message + "  " + ex.InnerException, null);
            }
        }

        //private object PronadjiAutor(int autorId)
        //{
        //    dynamic klijent = dBContext.UpravnoOsoblje.Where(k => k.Id == autorId).FirstOrDefault();
        //    if (klijent != null)
        //        return klijent;
        //    klijent = dBContext.Uposlenici.Where(k => k.Id == autorId).FirstOrDefault();
        //    return klijent;
        //}

        //private object PronadjiKlijenta(int klijentId)
        //{
        //    dynamic klijent = dBContext.KlijentiFizickoLice.Where(k => k.Id == klijentId).FirstOrDefault();
        //    if (klijent != null)
        //        return klijent;
        //    klijent = dBContext.KlijentiPravnoLice.Where(k => k.Id == klijentId).FirstOrDefault();
        //    return klijent;
        //}

        [HttpGet("{klijentId}")]
        public ResponseModel GetNarudzbeOnline(int klijentId)
        {
            try
            {
                //var klijent = dBContext.KlijentiPravnoLice.Where(k =>
                //   k.Id == klijentId).FirstOrDefault();

                //var klijent = PronadjiKlijenta(klijentId);
                //dynamic onlineNarudzbe=null;
                //if (klijent != null)
                //{
                //    //if (klijent is KlijentFizickoLice)
                //    //{
                //    //    onlineNarudzbe = dBContext.Narudzbe.ToList().Where(n =>
                //    // n.isOnline && n.KlijentFizickoLice ==
                //    // klijent).ToList();
                //    //}
                //    //else if (klijent is KlijentPravnoLice)
                //    //{
                //    //    onlineNarudzbe = dBContext.Narudzbe.ToList().Where(n =>
                //    //      n.isOnline && n.KlijentPravnoLice ==
                //    //      klijent).ToList();
                //    //}
                //}
                var onlineNarudzbe = dBContext.Narudzbe.Where(n => n.KlijentId == klijentId).ToList();
                return new ResponseModel(ResponseCode.OK,
                    "Online narudzbe za klijenta uspješno preuzete", onlineNarudzbe);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet]
        public ResponseModel GetAllNarudzbeOnline()
        {
            try
            {
                      
                var onlineNarudzbe = dBContext.Narudzbe.ToList().Where(n =>
                  n.isOnline).ToList();

                return new ResponseModel(ResponseCode.OK,
                    "Online narudzbe uspješno preuzete", onlineNarudzbe);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet("{datumKreiranja}")]

        public ResponseModel GetAllNarudzbe(DateTime datumKreiranja)
        {
            try
            {
                var narudzbe = dBContext.Narudzbe.Where(n => n.DatumNarudzbe.Date ==
                  datumKreiranja).ToList();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete narudžbe", narudzbe);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error,
                    "Greška -> " + ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet("{OD},{DO}")]

        public ResponseModel GetAllNarudzbeOdDo(DateTime OD,DateTime DO)
        {
            try
            {
                var narudzbe = dBContext.Narudzbe.Where(n => n.DatumNarudzbe.Date >=
                  OD.Date && n.DatumNarudzbe.Date<=DO.Date).ToList();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete narudžbe", narudzbe);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error,
                    "Greška -> " + ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet("{datum}")]

        public ResponseModel GetAllNarudzbeMjesec(DateTime datum)
        {
            try
            {
                var narudzbe = dBContext.Narudzbe.Where(n => n.DatumNarudzbe.Date.Month ==
                  datum.Month && n.DatumNarudzbe.Year==datum.Year).ToList();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete narudžbe", narudzbe);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error,
                    "Greška -> " + ex.Message + " " + ex.InnerException, null);
            }
        }
        [HttpGet("{godina}")]

        public ResponseModel GetAllNarudzbeGodina(int godina)
        {
            try
            {
                var narudzbe = dBContext.Narudzbe.Where(n => n.DatumNarudzbe.Year==
                godina).ToList();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete narudžbe", narudzbe);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error,
                    "Greška -> " + ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet]
        public ResponseModel GetIzvjestajiNarudzbe()
        {
            try
            {
                var narudzbe = dBContext.IzvjestajiNarudzbe.ToList();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete narudžbe", narudzbe);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error,
                    "Greška -> " + ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet("{id}")]
        public ResponseModel GetNarudzbeByIzvjestajId(int id)
        {
            try
            {
                var narudzbeIzvjestaji = dBContext.IzvjestajiNarudzbe.ToList()
                    .Where(ni => ni.IzvjestajId ==
                id).ToList();

                List<Narudzba> narudzbeList = new List<Narudzba>();
                foreach (var ni in narudzbeIzvjestaji)
                {
                    narudzbeList.Add(dBContext.Narudzbe.Where(n=>n.Id==ni.NarudzbaId).FirstOrDefault());
                }
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete narudžbe", narudzbeList);
            }
            catch (Exception ex)

            {

                return new ResponseModel(ResponseCode.Error,
                    "Greška -> " + ex.Message + " " + ex.InnerException, null);
            }
        }
    }

}
