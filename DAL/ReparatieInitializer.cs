using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Computer_Reparatieshop.Models;

namespace Computer_Reparatieshop.DAL
{
    public class ReparatieInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ReparatieContext>
    {
        protected override void Seed(ReparatieContext context)
        {
            var reparaties = new List<Reparatieopdrachten>
            {
                new Reparatieopdrachten{Name="test", Startdate = DateTime.Now, Enddate = DateTime.Now, Status = Status.Done}
            };

            reparaties.ForEach(s => context.reparatieopdrachtens.Add(s));
            context.SaveChanges();
        }
    }
}