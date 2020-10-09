using Computer_Reparatieshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.ViewModels
{
    public class OnderdelenReparatieViewModel
    {
       public ICollection<PartcheckboxViewmodel> CB { get; set; }
       public Reparatieopdracht RO { get; set; }

        public ComputerPart CP { get; set; }

    }
}