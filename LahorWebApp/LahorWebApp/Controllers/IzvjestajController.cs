using Data.Data;
using Data.Enum;
using Data.Models;
using LahorWebApp.ViewModels.Izvjestaj;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IzvjestajController
    {
        private readonly LahorAppDBContext dBContext;

        public IzvjestajController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost]
        public ResponseModel Add([FromBody] IzvjestajAddVM model)
        {
            try
            {
                Izvjestaj newIzvjestaj = new Izvjestaj
                {
                    Oznaka = "I",
                    DatumKreiranja = DateTime.Now,
                    VrstaIzvjestajaId = model.VrstaIzvjestajaId,
                    VrstaIzvjestaja = dBContext.VrsteIzvjestaja.Find(model.VrstaIzvjestajaId),
                    Autor=dBContext.Radnici.Find(model.AutorId)
                };
                dBContext.Add(newIzvjestaj);
                dBContext.SaveChanges();
                foreach (var n in model.Narudzbe)
                {
                    dBContext.Add(new IzvjestajiNarudzbe
                    {
                        IzvjestajId=newIzvjestaj.Id,
                        NarudzbaId=n.Id
                    });
                }
                dBContext.SaveChanges();
                return new ResponseModel(ResponseCode.OK,
                    "Izvještaj uspješno dodan", newIzvjestaj);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet]
        public ResponseModel GetAllIzvještaji()
        {
            try
            {
                var izvjestaji = dBContext.Izvjestaji.Select(i =>
                new IzvjestajGetVM
                {
                    AutorId = i.Autor.Id,
                    AutorNaziv = i.Autor.ToString(),
                    Oznaka = i.Oznaka,
                    VrstaIzvjestajaId=i.VrstaIzvjestajaId,
                    NazivVrsteIzvjestaja=i.VrstaIzvjestaja.ToString(),
                    DatumKreiranja=i.DatumKreiranja.Date.ToString("d.MM.yyyy")
                });
                    return new ResponseModel(ResponseCode.OK,
                        "Uspješno preuzeti izvještaji", izvjestaji);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet]
        public ResponseModel GetAllVrsteIzvjestaja()
        {
            try
            {
                var vrste = dBContext.VrsteIzvjestaja.ToList();
                return new ResponseModel(ResponseCode.OK,
                    "Vrste izvještaja uspješno preuzete", vrste);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }

        private object PronadjiAutoraIzvjestaja(int autorId)
        {
            dynamic autor = dBContext.UpravnoOsoblje.Where(uo =>
              uo.Id == autorId).FirstOrDefault();
            if (autor == null)
            {
                autor = dBContext.Uposlenici.Where(u =>
              u.Id == autorId).FirstOrDefault();
            }
            
            return autor;
        }
    }
}
