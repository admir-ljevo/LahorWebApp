using LahorWebApp.Data;
using LahorWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LahorWebApp.Helpers
{
    public static class Authentification
    {
        //public static Korisnik LogiraniKorisnik(this HttpContext httpContext)
        //{
        //    LahorAppDBContext db = httpContext.RequestServices.GetService<LahorAppDBContext>();

        //    UserManager<Korisnik> userManager = httpContext.RequestServices.
        //        GetService<UserManager<Korisnik>>();

        //    if (httpContext.User == null)
        //        return null;

        //    string userId = userManager.GetUserId(httpContext.User);

        //    //Korisnik korisnik = db.Korisnici.Where(k => k.Id == userId)
        //    //    .Include(k => k.Uposlenik)
        //    //    .Include(k => k.UpravnoOsoblje)
        //    //    .Include(k => k.KlijentFizickoLice)
        //    //    .Include(k => k.KlijentPravnoLice)
        //    //    .SingleOrDefault();

        //    return korisnik;
        //}
    }
}
