using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LahorWebApp.Models;

namespace LahorWebApp.Helpers
{
    public class AuthorizationAttribute:TypeFilterAttribute
    {
        public AuthorizationAttribute(
            bool omogucenoUposlenik,
            bool omogucenoUpravnoOsoblje,
            bool omogucenoKlijentPravnoLice,
            bool omogucenoKlijentFizickoLice):base(typeof(MyAuthorize))
        {
            Arguments = new object[]
            {
                omogucenoUposlenik,
                omogucenoUpravnoOsoblje,
                omogucenoKlijentPravnoLice,
                omogucenoKlijentFizickoLice
            };
        }
    }
    public class MyAuthorize : IActionFilter
    {
        private readonly bool _omogucenoUposlenik;
        private readonly bool _omogucenoUpravnoOsoblje;
        private readonly bool _omogucenoKlijentPravnoLice;
        private readonly bool _omogucenoKlijentFizickoLice;
        public MyAuthorize(
            bool omogucenoUposlenik,
            bool omogucenoUpravnoOsoblje,
            bool omogucenoKlijentPravnoLice,
            bool omogucenoKlijentFizickoLice)
        {
            _omogucenoUposlenik = omogucenoUposlenik;
            _omogucenoUpravnoOsoblje = omogucenoUpravnoOsoblje;
            _omogucenoKlijentPravnoLice = omogucenoKlijentPravnoLice;
            _omogucenoKlijentFizickoLice = omogucenoKlijentFizickoLice;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext httpContext = filterContext.HttpContext;

            Korisnik korisnik = httpContext.LogiraniKorisnik();

            if(korisnik==null)
            {
                if(filterContext.Controller is Controller controller)
                {
                    controller.TempData["ErrorPoruka"] = "Niste logirani";
                }
                return;
            }

            if(_omogucenoUposlenik && korisnik.Uposlenik!=null)
            {
                return;
            }

            if (_omogucenoUpravnoOsoblje && korisnik.UpravnoOsoblje != null)
            {
                return;
            }

            if (_omogucenoKlijentPravnoLice && korisnik.KlijentPravnoLice != null)
            {
                return;
            }

            if (_omogucenoKlijentFizickoLice && korisnik.KlijentFizickoLice != null)
            {
                return;
            }
        }
    }
}
