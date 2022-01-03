using Data.Data;
using Data.Helpers;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Views
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BracniStatusiController : ControllerBase
    {
        private readonly LahorAppDBContext dBContext;

        public BracniStatusiController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpPost]

        public BracniStatus Add([FromBody] BracniStatusiAddVM x)
        {
            var newBracniStatus = new BracniStatus {
                Naziv = x.Naziv
            };
            dBContext.Add(newBracniStatus);
            dBContext.SaveChanges();
            return newBracniStatus;
        }

        [HttpGet("{id}")]

        public BracniStatus GetById(int id)
        {
            return dBContext.BracniStatusi.Find(id);
        }

        [HttpGet]
        public List<BracniStatus> GetAll()
        {
            return dBContext.BracniStatusi.ToList();
        }

        [HttpGet]
        public List<CmbStavke> GetAllCmb()
        {
            var data = dBContext.BracniStatusi
                .OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.Id,
                    opis = s.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
