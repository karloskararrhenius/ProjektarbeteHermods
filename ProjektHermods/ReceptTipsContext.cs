using ProjektHermods.Models;
using System.Data.Entity;

namespace ProjektHermods
{
    public class ReceptTipsContext : DbContext
    {
        public ReceptTipsContext() : base("ReceptTipsDB") { }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
    }
}