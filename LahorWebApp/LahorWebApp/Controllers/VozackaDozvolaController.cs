using Data.Data;
using Data.Enum;
using Data.Models;
using LahorWebApp.ViewModels.VozackaDozvola;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VozackaDozvolaController
    {
        private readonly LahorAppDBContext dBContext;

        public VozackaDozvolaController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpPost]
        public ResponseModel Add([FromBody] VozackaDozvolaAddVM model)
        {
            try
            {
                if(model!=null)
                {
                    var vozackaDozvola = new VozackaDozvolaKategorija
                    {
                        Naziv = model.Naziv
                    };
                    dBContext.Add(vozackaDozvola);
                    dBContext.SaveChanges();
                    return new ResponseModel(ResponseCode.OK, "Vozačka dozvola " +
                        "uspješno dodana", vozackaDozvola);
                }
                return new ResponseModel(ResponseCode.Error, "Vrijednost koja je prosljeđena " +
                    "je null", null);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error, "Greška prilikom dodavanja, " +
                    "greška-> " + ex.Message,null);
            }
        }
    }
}
