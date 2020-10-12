using Computer_Reparatieshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.ViewModels
{
    public class CreateRepairViewModel
    {
        public Reparatieopdracht Reparatieopdracht { get; set; }
        public List<Klant> Klanten { get; set; }
        public int KlantId { get; set; }

        public List<Reparateur> reparateurs { get; set; }
        public int ReparateurId { get; set; }

        public int reparateurtime { get; set; }

        public List<ComputerPart> computerParts { get; set; }
        public int ComputerpartId { get; set; }
    }
}