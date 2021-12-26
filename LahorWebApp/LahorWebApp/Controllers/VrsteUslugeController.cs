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
    public class VrsteUslugeController:ControllerBase
    {
        private readonly LahorAppDBContext dBContext;

        public VrsteUslugeController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public ResponseModel GetAllUslugeCmb()
        {
            try
            {
                var vrsteUsluge = dBContext.VrsteUsluga
                .OrderBy(vu => vu.Naziv)
                .Select(vu => new CmbStavke()
                {
                    id = vu.Id,
                    opis = vu.Naziv,
                })
                .AsQueryable();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete" +
                    "usluge", vrsteUsluge);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }
    }
}
