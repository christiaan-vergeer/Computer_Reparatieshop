using Computer_Reparatieshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.ViewModels
{
    public class OnderdelenReparatieViewModel
    {
       public Reparatieopdracht Reparatieopdracht { get; set; }        
       public IList<int> MemmoryID { get; set; }
       public IList<string> Partname { get; set; }
       public IList<bool> checker { get; set; }

    }
}