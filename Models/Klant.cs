using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Computer_Reparatieshop.Models
{
    public class Klant
    {
        public int Id { get; set; }
        public string Firstname {get; set;}
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }
        public string Phonenumber { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public Boolean isdeleted { get; set; }

        public virtual ICollection<Reparatieopdracht> Reparatieopdrachtens { get; set; }
    }
}