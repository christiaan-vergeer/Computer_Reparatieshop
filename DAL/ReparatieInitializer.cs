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
            var reparaties = new List<Reparatieopdracht>
            {
                new Reparatieopdracht{Name="test1", Startdate = DateTime.Parse("2020-10-02"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.Pending},
                new Reparatieopdracht{Name="test2", Startdate = DateTime.Parse("2020-10-01"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.Pending},
                new Reparatieopdracht{Name="test3", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.Pending},
                new Reparatieopdracht{Name="test4", Startdate = DateTime.Parse("2020-10-21"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.InProgress},
                new Reparatieopdracht{Name="test5", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.WaitingForParts},
                new Reparatieopdracht{Name="test6", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.WaitingForParts},
                new Reparatieopdracht{Name="test7", Startdate = DateTime.Parse("2020-11-02"), Enddate = DateTime.Parse("2020-10-22"), Status = Status.Done}
            };

            reparaties.ForEach(s => context.reparatieopdrachtens.Add(s));
            context.SaveChanges();

            var klantens = new List<Klant>
            {
                new Klant{Firstname="chris",Middlename="",Lastname="vergeer",Phonenumber="06-11799450",Adress="gildestraat 17",City="Amserfoort"},
                new Klant{Firstname="joop",Middlename="",Lastname="Harrold",Phonenumber="06-11745350",Adress="amerforosterweg 23",City="Amsterdam"},
                new Klant{Firstname="bart",Middlename="van der",Lastname="bos",Phonenumber="06-12312350",Adress="harrlodweg 123",City="delft"},
                new Klant{Firstname="marry",Middlename="der",Lastname="linde",Phonenumber="06-23718247",Adress="amsterdamseweg 1",City="maastricht"}
            };

            klantens.ForEach(s => context.klantens.Add(s));
            context.SaveChanges();
        }
    }
}