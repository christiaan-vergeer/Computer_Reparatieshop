using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.Models
{
    public class Reparateur
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string InFix { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        public double Wage { get; set; }
        public virtual ICollection<Reparatieopdracht> Reparatieopdrachts { get; set; }
    }
}