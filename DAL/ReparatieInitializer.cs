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
                new Reparatieopdrachten{Name="test1", Startdate = DateTime.Parse("2020-10-02"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.Pending},
                new Reparatieopdrachten{Name="test2", Startdate = DateTime.Parse("2020-10-01"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.Pending},
                new Reparatieopdrachten{Name="test3", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.Pending},
                new Reparatieopdrachten{Name="test4", Startdate = DateTime.Parse("2020-10-21"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.InProgress},
                new Reparatieopdrachten{Name="test5", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.WaitingForParts},
                new Reparatieopdrachten{Name="test6", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.WaitingForParts},
                new Reparatieopdrachten{Name="test7", Startdate = DateTime.Parse("2020-11-02"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.Done}
            };

            reparaties.ForEach(s => context.reparatieopdrachtens.Add(s));
            context.SaveChanges();
        }
    }
}