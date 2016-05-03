﻿using ProjektHermods.Models;
using System.Web.Mvc;

namespace ProjektHermods.Controllers
{
    public class LogInLogOutController : Controller
    {
        // GET: LogInLogOut
        public ActionResult Index()
        {
            using (ReceptTipsContext context = new ReceptTipsContext())
            {
                // Nödvändiga variabler för inloggning
                string username = Request["loginname"];
                string password = Request["loginpassword"];

                string logoutButton = Request["logoutButton"];

                //Om username INTE är null
                if (username != null)
                {
                    // Testa att användarnamn och lösenord
                    foreach (UserModel u in context.UserModels)
                    {
                        //Om Användrnamn stämmer
                        if (username == u.Name)
                        {
                            //Om password stämmer
                            if (password == u.Password)
                            {
                                //Lägger användarnamnet i en SEKTION
                                Session["username"] = username;

                                //Slår om ISLOGGEDIN-sektionen till TRUE!
                                Session["IsLoggedIn"] = true;
                                //Åker tillbaka till startsidan
                                return Redirect("/");
                            }
                        }
                    }
                }
                else if (logoutButton != null)
                {
                    // Om anv trycker på logga ut

                    //Nollar vi då user/isloggedin Sessionerna!!!
                    Session["username"] = null;
                    Session["IsLoggedIn"] = false;  
                }
            }
            return View();
        }
    }
}