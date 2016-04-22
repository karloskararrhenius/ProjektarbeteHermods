using ProjektHermods.Models;
using System.Linq;
using System.Web.Mvc;

namespace ProjektHermods.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            //Skapa en DB-anslutning
            using (ReceptTipsContext context = new ReceptTipsContext())
            {
                //Kolla hur många maträtter det finns i DB
                int nrOfFood = context.Foods.Count();
                //Om det är NOLL så skapar vi 10 stycken här:
                if (nrOfFood == 0)
                {
                    #region 10 maträtter läggs till "ADD"
                    string foodToAdd = "";
                    for (int i = 1; i <= 10; i++)
                    {
                        if (i == 1)
                            foodToAdd = "Grekisk Sallad";
                        else if(i == 2)
                            foodToAdd = "Hawaii";
                        else if (i == 3)
                            foodToAdd = "Flygande Jacob";
                        else if (i == 4)
                            foodToAdd = "Fisksoppa";
                        else if (i == 5)
                            foodToAdd = "Pannkakor";
                        else if (i == 6)
                            foodToAdd = "Fiskpinnar";
                        else if (i == 7)
                            foodToAdd = "Kycklingfilé";
                        else if (i == 8)
                            foodToAdd = "Potatisgratäng";
                        else if (i == 9)
                            foodToAdd = "Korv med bröd";
                        else if (i == 10)
                            foodToAdd = "Nudlar";

                        //Skapar variabel
                        Food x = new Food()
                        {
                            foodName = foodToAdd
                        };

                        //Lägger till i listan
                        context.Foods.Add(x);
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