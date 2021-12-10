using LahorWebApp.Data;
using LahorWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Views
{
    
    [Route("[controller]/[action]")]
    public class BracniStatusiController : ControllerBase
    {
        private readonly LahorAppDBContext dBContext;

        public BracniStatusiController(LahorAppDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        [HttpPost]

        public BracniStatus Add(BracniStatusiVM x)
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
    }
}
