using Data.Data;
using Data.Enum;
using Data.Helpers;
using Data.Models;
using LahorWebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LahorWebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ObavijestController:ControllerBase
    {
        private readonly LahorAppDBContext dBContext;

        public ObavijestController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [Authorize(Roles ="Admin,UpravnoOsoblje")]
        [HttpPost]
        public ResponseModel Add([FromBody] ObavijestAddVM model)
        {
            try
            {
                Obavijest newObavijest = new Obavijest
                {
                    Naslov = model.Naslov,
                    DatumKreiranja = DateTime.Now.Date,
                    AutorId = model.AutorId,
                    Sadrzaj = model.Sadrzaj,
                    JavnaObavijest = model.JavnaObavijest,
                    SlikaObavještenja = Config.SlikeURL + "empty.png"
                };
                if(newObavijest!=null)
                {
                    dBContext.Add(newObavijest);
                    dBContext.SaveChanges();
                    return new ResponseModel(ResponseCode.OK, "Obavijest uspješno dodana",
                    newObavijest);
                }
                return new ResponseModel(ResponseCode.Error, "Obavijest->null",
                    newObavijest);
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Obavijest nije dodana , " +
                    "Greška -> "+ex.Message,
                   null);
            }
        }
    }
}
