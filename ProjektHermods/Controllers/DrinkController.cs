using ProjektHermods.Models;
using System.Linq;
using System.Web.Mvc;

namespace ProjektHermods.Controllers
{
    public class DrinkController : Controller
    {
        // GET: Drink
        public ActionResult Index()
        {
            //Skapa en DB-anslutning
            using (ReceptTipsContext context = new ReceptTipsContext())
            {
                //Kolla hur många drinkar det finns i DB
                int nrOfDrink = context.Drinks.Count();
                //Om det är NOLL så skapar vi 10 stycken här:
                if (nrOfDrink == 0)
                {
                    #region 10 drinkar läggs till "ADD"
                    string drinkToAdd = "";
                    for (int i = 1; i <= 10; i++)
                    {
                        if (i == 1)
                            drinkToAdd = "White Russian";
                        else if (i == 2)
                            drinkToAdd = "Jäger Redbull";
                        else if (i == 3)
                            drinkToAdd = "P2";
                        else if (i == 4)
                            drinkToAdd = "Rödvin";
                        else if (i == 5)
                            drinkToAdd = "Öl";
                        else if (i == 6)
                            drinkToAdd = "Whiskey";
                        else if (i == 7)
                            drinkToAdd = "Lakritsshots";
                        else if (i == 8)
                            drinkToAdd = "Cider";
                        else if (i == 9)
                            drinkToAdd = "Färnet";
                        else if (i == 10)
                            drinkToAdd = "Gammeldansk";

                        //Skapar variabel
                        Drink x = new Drink()
                        {
                            drinkName = drinkToAdd
                        };

                        //Lägger till i listan
                        context.Drinks.Add(x);
                    }
                    #endregion

                    //Sparar ändringar
                    context.SaveChanges();
                }
            }
            return View();
        }
    }
}