using Computer_Reparatieshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.ViewModels
{
    public class OnderdelenReparatieViewModel
    {
       public ICollection<ComputerPart> computerParts { get; set; }
       public Reparatieopdracht reparatieopdracht { get; set; }
    }
}