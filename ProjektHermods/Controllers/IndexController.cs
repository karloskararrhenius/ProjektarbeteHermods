using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektHermods.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kontakt()
        {
            return View();
        }
        public ActionResult FormulärSkickat()
{
return View();
}

        //om det uppstår ett fel på vår sida så vissas denna sidan istället
        public ActionResult Error()

        {
            return View();
        }
    }
}