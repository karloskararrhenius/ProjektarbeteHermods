using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Sql;
using System.Web.Mvc;
using ProjektHermods.Models;

namespace ProjektHermods.Controllers
    {
    public class SearchController : Controller
        {
        // GET: Search
        public ActionResult Index()
            {


            return View();
            }

        public ActionResult Testing()
            {
            //int identifier;
            //var isInt = int.TryParse(Request.QueryString["id"], out identifier);
            //Ingrediens context = new Ingrediens();
            //if(context.Id ==identifier)
            //    {
            //    context.ChosenIngredient++;
            //    }

            return View();
            }

        public JsonResult AutoCompleteIngrediens(string term)
            {
            ReceptTipsContext context = new ReceptTipsContext();

            var result = (from r in context.Ingrediens
                          where r.Name.ToLower().StartsWith(term.ToLower())
                          select new { r.Name }).Distinct();

            return Json(result, JsonRequestBehavior.AllowGet);

            }
        }
    }