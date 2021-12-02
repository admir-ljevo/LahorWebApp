using LahorWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Data
{
    public class LahorAppDBContext:DbContext
    {
        
        public LahorAppDBContext(DbContextOptions options):base(options)
        {

        }
    }
}
