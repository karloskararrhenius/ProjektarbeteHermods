using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjektHermods
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Session_Start(object sender, EventArgs e) //Startup
        {
            //Variabel för info om man är inloggad
            Session["IsLoggedIn"] = false;
        }
    }
}