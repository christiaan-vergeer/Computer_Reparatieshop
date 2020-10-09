using Computer_Reparatieshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.ViewModels
{
    public class PartcheckboxViewmodel : ComputerPart
    {
        public ComputerPart ComputerPart { get; set; }
        public bool IsChecked { get; set; }
    }
}