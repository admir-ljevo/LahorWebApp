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
        public virtual DbSet<Spol> Spolovi { get; set; }
        public virtual DbSet<BracniStatus> BracniStatusi { get; set; }
        public virtual DbSet<Uposlenik> Uposlenici { get; set; }
        public virtual DbSet<UpravnoOsoblje> UpravnoOsoblje { get; set; }
        public virtual DbSet<KlijentFizickoLice> KlijentiFizickoLice { get; set; }
        public virtual DbSet<KlijentPravnoLice> KlijentiPravnoLice { get; set; }
        public virtual DbSet<VoazckaDozvolaKategorija> VoazckaDozvolaKategorije { get; set; }
        public LahorAppDBContext(DbContextOptions options):base(options)
        {

        }
    }
}
