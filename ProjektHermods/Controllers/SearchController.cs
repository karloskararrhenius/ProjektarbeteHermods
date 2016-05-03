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

        public ActionResult Index()
            {
         
            ReceptTipsContext context = new ReceptTipsContext();
            List<string> keys = new List<string>(Request.QueryString.AllKeys);
            List<string> list = new List<string>();
            if (keys.Count != 0)
            {
                foreach (var item in context.Recepts)
                {
                    string s = item.Name;
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["ingrediens"]))
                    {
                        var albums = new List<Ingrediens>();
                        var query = Request.QueryString["ingrediens"];
                        string[] words = query.Split(',');

                        string p = words[0];
                        Ingrediens ing = new Ingrediens();
                        ing.Name = p;
                        Recept rec = new Recept();

                        Ingrediens testing = new Ingrediens();
                        var temp = from i in context.Recepts
                                   where words.All(i.Ingredients)
                                   select i;



                    }
                }
            }
                return View();
            }

        [HttpPost]
        public ActionResult Index(string buttonAdd)
            {
            ReceptTipsContext context = new ReceptTipsContext();
            foreach(var item in context.Ingrediens)
                {
                if(Request.QueryString[item.Name]!=null)
                    {

                    }
                string nameOnItem = Request["Tomat"];
                if(Request["buttonAdd"]!=null)
                    {

                    string a = Request["Tomat"]; //Sätter nameOnItem till det du skrivr i formuläret
                    string ingrediensType = Request[item.Name]; ////Sätter ingredienstype till det du skrivr i formuläret
                    string infoAboutItem = Request[item.Name]; //Sätter infoaboutitem till det du skrivr i formuläret
                    string pictureLink = Request.Form[item.Name]; //Bildadress, "img/nophoto.jpg" = (För standardbild)
                    string allIngrediends = Request.QueryString[item.Name]; //Sätter allingrediends till det du skrivr i formuläret
                    }
                }
            return View();
            }
        public JsonResult AutoCompleteIngrediens(string term)
            {
            ReceptTipsContext context = new ReceptTipsContext();

            if(term.Contains("*"))
                {


                var result = (from r in context.Ingrediens
                              orderby r.Name

                              select new { r.Name }).Distinct();
                return Json(result, JsonRequestBehavior.AllowGet);

                }
            else
                {
                var result = (from r in context.Ingrediens
                              orderby r.Name
                              where r.Name.ToLower().StartsWith(term.ToLower())
                              select new { r.Name }).Distinct();
                return Json(result, JsonRequestBehavior.AllowGet);
                }


            }
        }
    }