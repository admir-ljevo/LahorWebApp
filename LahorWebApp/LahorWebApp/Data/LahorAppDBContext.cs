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
        
<<<<<<< HEAD
=======
        public virtual DbSet<Spol> Spolovi { get; set; }
        public virtual DbSet<BracniStatus> BracniStatusi { get; set; }
>>>>>>> f242c777a5ca36266fe49af796a643fbf935cda5
        public LahorAppDBContext(DbContextOptions options):base(options)
        {

        }
    }
}
