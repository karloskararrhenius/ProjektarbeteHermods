using System.Collections.Generic;

namespace ProjektHermods.Models
{
    public class Recept
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ChoosenType ChoosenTypes { get; set; }
        public string Info { get; set; }
        public string Picture { get; set; }
        public virtual IList<Ingrediens> Ingredients { get; set; }
    }
}