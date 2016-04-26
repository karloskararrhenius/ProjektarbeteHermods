﻿using ProjektHermods.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using System.Linq;

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

            //####################################################//
            List<string> allIngrediends; //Lagra ingredienser     //
            //####################################################//
            //  Metoden: "AddRecipeToDB()" - FEM Parametrar:      //
            //  (1)Namn, (2)Typ, (3)Info, (4)Bild, (5)Ingrediens  //
            //####################################################//
            #region Lägga in Data i DB(Om den är tom)
            int thingsInDB;
            using (ReceptTipsContext context = new ReceptTipsContext())
            {
                thingsInDB = context.Recepts.Count();
            }
            if(thingsInDB == 0) {
                allIngrediends = new List<string>() { "Tomat", "Ost" };
                AddRecipeToDB("Margherta", "Mat", "How to do...", "/img/nophoto.jpg", allIngrediends);

                allIngrediends = new List<string>() { "Tomat", "Ost", "Skinka" };
                AddRecipeToDB("Vesuvio", "Mat", "How to do...", "/img/nophoto.jpg", allIngrediends);

                allIngrediends = new List<string>() { "Tomat", "Ost", "Skinka", "Ananas" };
                AddRecipeToDB("Hawaii", "Mat", "How to do...", "/img/nophoto.jpg", allIngrediends);

                allIngrediends = new List<string>() { "Tomat", "Ost", "Kebabkött", "Gurka", "Isbergssallad", "Pepperoni", "Kebabsås" };
                AddRecipeToDB("Kebabpizza", "Mat", "How to do...", "/img/nophoto.jpg", allIngrediends);

                allIngrediends = new List<string>() { "Vaniljvodka", "Sourz Sour Apple", "Limejuice", "Fruktsoda" };
                AddRecipeToDB("P2", "Dricka", "How to do...", "/img/nophoto.jpg", allIngrediends);

                allIngrediends = new List<string>() { "Vodka", "Blå curacao", "Sprite" };
                AddRecipeToDB("Blue Lagoon", "Dricka", "How to do...", "/img/nophoto.jpg", allIngrediends);

                allIngrediends = new List<string>() { "Whiskey", "Martini rosso", "Angostura bitter" };
                AddRecipeToDB("Manhattan", "Dricka", "How to do...", "/img/nophoto.jpg", allIngrediends);

                allIngrediends = new List<string>() { "Rom", "Malibu", "Mjölk", "Ananasjuice" };
                AddRecipeToDB("Piña Colada", "Dricka", "How to do...", "/img/nophoto.jpg", allIngrediends);
            }
            #endregion
        }
        public void AddRecipeToDB(string nameOnItem2, string ingrediensType2, string infoAboutItem2, string pictureLink2, List<string> allIngrediends2)
        {
            //Skapa massa "startdata" till DB vid startup (Om DB är tom)
            using (ReceptTipsContext context = new ReceptTipsContext())
            {
                ///##############################################///
                /// Alla variabler som behövs för ett nytt Recept///
                ///##############################################///
                string nameOnItem = nameOnItem2; //Namn på grejen!
                string ingrediensType = ingrediensType2; //Dricka eller Mat
                string infoAboutItem = infoAboutItem2; //Diverse info
                string pictureLink = pictureLink2; //Bildadress, "img/nophoto.jpg" = (För standardbild)
                List<string> allIngrediends = allIngrediends2; //ListVariabel för Valda ingredienser

                #region Lägga till vald Ingrediens i en Lista (Till Fullständiga receptet sen)
                //Skapa en TOM Lista för nytt Recept
                IList<Ingrediens> nuvarandeReceptLista = new List<Ingrediens>();
                for (int i = 0; i < allIngrediends.Count(); i++)
                {
                    string newIngrediens = allIngrediends[0];
                    allIngrediends.RemoveAt(0);

                    //Skapa variabel av ny ingrediens
                    Ingrediens nyIng;
                    //Hämta vald ingrediens till en lista
                    var listWithChoosenIng = context.Ingrediens.Where(ing => ing.Name == newIngrediens);
                    //Om den finns sen innan tar vi den datan, _annars_ skapar vi en ny
                    if (listWithChoosenIng.Count() > 0)
                        nyIng = listWithChoosenIng.First();
                    else
                        nyIng = new Ingrediens() { Name = newIngrediens };

                    //Lägga till i nuvarande listan:
                    nuvarandeReceptLista.Add(nyIng);
                }
                #endregion
                #region Val av typ (Till Receptet)
                //Skapa variabel av typen MAT eller DRICKA
                ChoosenType choosenType;
                //Hämta vald ingrediens till en lista
                var listWithChoosenType = context.ChoosenTypes.Where(ing => ing.Typ == ingrediensType);
                //Om den finns sen innan tar vi den datan, _annars_ skapar vi en ny
                if (listWithChoosenType.Count() > 0)
                    choosenType = listWithChoosenType.First();
                else
                    choosenType = new ChoosenType() { Typ = ingrediensType };
                #endregion
                #region Skapa Receptet och lägga till aktuella ingredienser i DB
                //Lägga till KOMPLETT recept
                Recept nyttRecept = new Recept()
                {
                    Name = nameOnItem,
                    ChoosenTypes = choosenType,
                    Info = infoAboutItem,
                    Picture = pictureLink,
                    Ingredients = nuvarandeReceptLista
                };
                //Nolla nuvarande listan
                nuvarandeReceptLista = new List<Ingrediens>();

                //Lägga till i lista för DB
                context.Recepts.Add(nyttRecept);

                //Spara ändringar till DB
                context.SaveChanges();
                #endregion
            }
        }
    }
}