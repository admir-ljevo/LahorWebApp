using Data.Data;
using Data.Enum;
using Data.Helpers;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LahorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NivoIzvrsenjaController:ControllerBase
    {

        private readonly LahorAppDBContext dBContext;

        public NivoIzvrsenjaController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public ResponseModel GetAllNivoIzvrsenjaCmb()
        {
            try
            {
                var vrsteUsluge = dBContext.NivoIzvrsenjaUsluge
                .OrderBy(vu => vu.Naziv)
                .Select(vu => new CmbStavke()
                {
                    id = vu.Id,
                    opis = vu.Naziv,
                })
                .AsQueryable();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzeti" +
                    "nivoi izvršenja", vrsteUsluge);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }
    }
}
