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
    public class UslugeController:ControllerBase
    {
        private readonly LahorAppDBContext dBContext;

        public UslugeController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public ResponseModel GetAllUslugeCmb()
        {
            try
            {
                var usluge = dBContext.Usluge
                .OrderBy(u => u.NazivUsluge)
                .Select(u => new CmbStavke()
                {
                    id = u.Id,
                    opis = u.NazivUsluge,
                })
                .AsQueryable();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete" +
                    "usluge", usluge);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }

        [HttpGet("{vrstaUslugeId}")]
        public ResponseModel GetUslugeCmbByVrsta(int vrstaUslugeId)
        {
            try
            {
                if (vrstaUslugeId == null)
                    return new ResponseModel(ResponseCode.Error, "Vrsta usluge je" +
                        "null", null);
                var usluge = dBContext.Usluge.Where(u=>u.VrstaUslugeId==vrstaUslugeId)
                .OrderBy(u => u.NazivUsluge)
                .Select(u => new CmbStavke()
                {
                    id = u.Id,
                    opis = u.NazivUsluge,
                })
                .AsQueryable();
                return new ResponseModel(ResponseCode.OK, "Uspješno preuzete" +
                    "usluge", usluge);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška -> " +
                    ex.Message + " " + ex.InnerException, null);
            }
        }
    }
}
