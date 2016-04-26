using ProjektHermods.Models;
using System.Data.Entity;

namespace ProjektHermods
{
    public class ReceptTipsContext : DbContext
    {
        public ReceptTipsContext() : base("ReceptTipsDB") { }

        public DbSet<Ingrediens> Ingrediens { get; set; }
        public DbSet<Recept> Recepts { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<ChoosenType> ChoosenTypes { get; set; }
    }
}