using Computer_Reparatieshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.ViewModels
{
    public class OnderdelenReparatieViewModel
    {
       public ICollection<PartcheckboxViewmodel> checkbox { get; set; }
       public Reparatieopdracht Reparatieopdracht { get; set; }

       // public ComputerPart ComputerPart { get; set; }

    }
}