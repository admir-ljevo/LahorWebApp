using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Data.Data
{
    public class LahorAppDBContext:IdentityDbContext<Korisnik>
    {
      
        public LahorAppDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFK = modelBuilder.Model.GetEntityTypes()
               .SelectMany(x => x.GetForeignKeys())
               .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFK)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Korisnik>()
            //    .HasOne<Uposlenik>(s => s.Uposlenik)
            //    .WithOne(ad => ad.Korisnik)
            //    .HasForeignKey<Uposlenik>(ad => ad.KorisnikID);

            //modelBuilder.Entity<Korisnik>()
            //    .HasOne<UpravnoOsoblje>(s => s.UpravnoOsoblje)
            //    .WithOne(ad => ad.Korisnik)
            //    .HasForeignKey<UpravnoOsoblje>(ad => ad.KorisnikID);
            //modelBuilder.Entity<Korisnik>()
            //   .HasOne<KlijentPravnoLice>(s => s.KlijentPravnoLice)
            //   .WithOne(ad => ad.Korisnik)
            //   .HasForeignKey<KlijentPravnoLice>(ad => ad.KorisnikID);
            //modelBuilder.Entity<Korisnik>()
            //   .HasOne<KlijentFizickoLice>(s => s.KlijentFizickoLice)
            //   .WithOne(ad => ad.Korisnik)
            //   .HasForeignKey<KlijentFizickoLice>(ad => ad.KorisnikID);
        }
        public DbSet<Spol> Spolovi { get; set; }
        public DbSet<BracniStatus> BracniStatusi { get; set; }
        public DbSet<Uposlenik> Uposlenici { get; set; }
        public DbSet<UpravnoOsoblje> UpravnoOsoblje { get; set; }
        public DbSet<KlijentFizickoLice> KlijentiFizickoLice { get; set; }
        public DbSet<KlijentPravnoLice> KlijentiPravnoLice { get; set; }
        public DbSet<VoazckaDozvolaKategorija> VoazckaDozvolaKategorije { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Obavijest> Obavještenja { get; set; }

    }
}
