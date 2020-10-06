using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.Models
{
    public class ComputerPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public vendor Vendor { get; set; }
        public virtual ICollection<Reparatieopdracht> Reparatieopdracht { get; set; }
    }

    public enum vendor
    {
        None,
        MSI,
        Gigabyte,
        IBM,
        HP,
        Lenovo,
        Intel,
        AMD
    }
}