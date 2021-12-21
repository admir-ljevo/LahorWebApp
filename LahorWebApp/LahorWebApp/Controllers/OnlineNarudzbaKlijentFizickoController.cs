using Data.Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LahorWebApp.ViewModels;
using LahorWebApp.ViewModels.OnlineNarudzbaKlijentFizicko;
using Data.Enum;

namespace LahorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OnlineNarudzbaKlijentFizickoController : ControllerBase
    {

        private readonly LahorAppDBContext dBContext;
        public OnlineNarudzbaKlijentFizickoController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost]
        public ResponseModel Add([FromBody] OnlineNarudzbaKlijentFizickoAddVM model)
        {
            try
            {
                NarudzbaOnlineKlijentFizicko novaNarudzba = new NarudzbaOnlineKlijentFizicko
                {
                    KlijentFizickoLiceId = model.KlijentId,
                    Naziv = model.Naziv,
                    DatumNarudzbe=DateTime.Now.Date,
                    DatumIsporuke=model.DatumIsporuke,
                    Cijena=model.Cijena,
                    Kolicina=model.Kolicina,
                    
                    Opis=model.Opis
                };
                  
                if(novaNarudzba!=null)
                {
                    dBContext.Add(novaNarudzba);
                    dBContext.SaveChanges();
                    return new ResponseModel(ResponseCode.OK, "Narudžba uspješno dodana.", novaNarudzba);
                }

                return new ResponseModel(ResponseCode.Error, "Narudžba nije pronađena. ", novaNarudzba);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error, "Narudžba nije dodana. " + ex.Message + "  "  + ex.InnerException, null);
            }
        }

    }
}
