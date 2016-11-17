using MarvelApi;
using MarvelApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMarvel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MarvelRequester r = new MarvelRequester();
            List<Characters> info =r.GetCharacters(limit:100);

            return View(info);
        }

        public ActionResult About()
        {
            StarWarsRequester r = new StarWarsRequester();

            return View(r.GetPersos());
        }

        public ActionResult Contact()
        {
            PokemonRequester r = new PokemonRequester();


            return View(r.CatchThemAll());
        }
    }
}