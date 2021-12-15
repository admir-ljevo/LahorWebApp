using Data.Data;
using Data.Enum;
using Data.Helpers;
using Data.Models;
using LahorWebApp.ViewModels;
using LahorWebApp.ViewModels.Obavijesti;
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

        //[Authorize(Roles ="Admin,UpravnoOsoblje")]
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

        //[Authorize(Roles = "Admin,UpravnoOsoblje,Uposlenik")]
        [HttpGet]
        public ResponseModel GetAllObavijesti()
        {
            try
            {
                var obavijesti = dBContext.Obavještenja.Select(o => new ObavijestGetVM
                {
                    AutorId = o.AutorId,
                    Naslov = o.Naslov,
                    Sadrzaj = o.Sadrzaj,
                    Slika = o.SlikaObavještenja,
                    DatumKreiranja = o.DatumKreiranja,
                    JavnaObavijest = o.JavnaObavijest
                }).ToList();
                return new ResponseModel(ResponseCode.OK,
                    "Obavještenja uspješno preuzeta", obavijesti);
            }
            catch (Exception ex)
            {

                return new ResponseModel(ResponseCode.Error, "Greška prilikom preuzimanja" +
                    "obavještenja. Greška -> "+ex.Message, null);
            }   
        }

        //[Authorize(Roles = "Admin,UpravnoOsoblje,Uposlenik")]
        [HttpGet]
        public ResponseModel GetObavijestById(int id)
        {
            try
            {
                if(id==null)
                {
                    return new ResponseModel(ResponseCode.Error, "Vrijednost id=null",
                        null);
                }
                var obavijest = dBContext.Obavještenja.ToList().Where(
                    o => o.Id == id).FirstOrDefault();

                if(obavijest==null)
                {
                    return new ResponseModel(ResponseCode.Error, "Obavijest nije pronađena",
                        null);
                }

                return new ResponseModel(ResponseCode.OK, "Obavijest preuzeta", new ObavijestGetVM
                {
                    Naslov = obavijest.Naslov,
                    AutorId=obavijest.AutorId,
                    Sadrzaj=obavijest.Sadrzaj,
                    JavnaObavijest=obavijest.JavnaObavijest,
                    Slika=obavijest.SlikaObavještenja,
                    DatumKreiranja=obavijest.DatumKreiranja
                });
            }
            catch (Exception ex)
            {
                return new ResponseModel(ResponseCode.Error, "Greška prilikom preuzimanja" +
                    " obavijesti. Greška-> "+ex.Message,
                        null);
            }
        }

        [HttpPost("{id}")]
        public ResponseModel UpdateObavijest(int id,[FromBody] ObavijestUpdateVM model)
        {
            if (id == null)
                return new ResponseModel(ResponseCode.Error, "id je null", null);

            Obavijest obavijest = dBContext.Obavještenja.Where(o => o.Id == id).FirstOrDefault();

            if(obavijest==null)
            {
                return new ResponseModel(ResponseCode.Error, "Obavijest nije pronađena, id" +
                    "je pogrešan", null);
            }

            obavijest.Naslov = model.Naslov;
            obavijest.Sadrzaj = model.Sadrzaj;
            obavijest.JavnaObavijest = model.JavnaObavijest;
            obavijest.DatumKreiranja = DateTime.Now;

            dBContext.SaveChanges();

            return new ResponseModel(ResponseCode.OK, "Obavijest uspješno " +
                "modifikovana", obavijest);
        }
    }
}
