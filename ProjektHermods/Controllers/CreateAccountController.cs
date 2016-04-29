using ProjektHermods.Models;
using System.Web.Mvc;

namespace ProjektHermods.Controllers
{
    public class CreateAccountController : Controller
    {
        
        // GET: CreateAccount
        public ActionResult Index()
        {
            using (ReceptTipsContext context = new ReceptTipsContext())
            {
                //Om skapa-konto-knappen har blivit använd
                if (Request["createaccountbutton"] != null)
                {
                    //Ta emot inputs
                    string nameinput = Request["nameinput"];
                    string passwordinput = Request["passwordinput"];
                    string password2input = Request["passwordinput2"];

                    //Meddelande till användaren om kontot skapats eller felmeddelanden
                    string messageToUser = "";

                    //Lagra eventuella fel
                    string fel = "";
                    if (nameinput == "")
                        fel += "* Du glömde använarnamn. ";
                    if (passwordinput == "" || password2input == "")
                        fel += "* Du glömde lösenord på båda delarna. ";
                    if (passwordinput != null && password2input != null && passwordinput != password2input)
                        fel += "* Lösenorden stämmer inte överrens. ";

                    //Kika om användarnamnet är upptaget också förstås
                    foreach (UserModel item in context.UserModels)
                    {
                        if (item.Name == nameinput)
                            fel += "* Användarnamnet är upptaget. ";
                    }

                    //Om det var noll fel skapar vi kontot
                    if (fel == "")
                    {
                        UserModel newUser = new UserModel()
                        {
                            Name = nameinput,
                            Password = passwordinput
                        };
                        context.UserModels.Add(newUser);
                        context.SaveChanges();

                        //Lägger användarnamnet i en SEKTION
                        Session["username"] = nameinput;
                        //Slår om ISLOGGEDIN-sektionen till TRUE!
                        Session["IsLoggedIn"] = true;

                        //Skicka iväg ett meddelande
                        ViewBag.messageToUserAccountCreated = "Skapat konto!";
                    }
                    else
                    {
                        //Slänga med errormeddelandet
                        messageToUser = "Error! Följande fel: ";
                        messageToUser += fel;

                        ViewBag.messageToUser = messageToUser;
                    }
                }
            }
            return View();
        }
    }
}