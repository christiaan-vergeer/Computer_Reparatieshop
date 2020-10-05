using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Computer_Reparatieshop.Models;
using Computer_Reparatieshop.ViewModels;

namespace Computer_Reparatieshop.DAL
{
    public class ReparatieInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ReparatieContext>
    {
        protected override void Seed(ReparatieContext context)
        {
            var klantens = new List<Klant>
            {
                new Klant{Firstname="chris",Middlename="",Lastname="vergeer",Fullname="chris vergeer",Phonenumber="06-11799450",Adress="gildestraat 17",City="Amserfoort"},
                new Klant{Firstname="joop",Middlename="",Lastname="Harrold",Fullname="joop Harrold",Phonenumber="06-11745350",Adress="amerforosterweg 23",City="Amsterdam"},
                new Klant{Firstname="bart",Middlename="van der",Lastname="bos",Fullname="bart van der bos",Phonenumber="06-12312350",Adress="harrlodweg 123",City="delft"},
                new Klant{Firstname="marry",Middlename="der",Lastname="linde",Fullname="marry der linde",Phonenumber="06-23718247",Adress="amsterdamseweg 1",City="maastricht"}
            };

            klantens.ForEach(s => context.klantens.Add(s));
            context.SaveChanges();


            var reparaties = new List<Reparatieopdracht>
            {
                new Reparatieopdracht{Name="vervangen computerscherm", Startdate = DateTime.Parse("2020-10-02"), Enddate = DateTime.Parse("2020-10-22"), Klant = klantens.FirstOrDefault(r => r.Id == 1) ,Details = "zit een barst in het beeldscherm, verder geen schade", Status = Status.Pending},
                new Reparatieopdracht{Name="kappot toetsenbord", Startdate = DateTime.Parse("2020-10-01"), Enddate = DateTime.Parse("2020-10-22"), Klant = klantens.FirstOrDefault(r => r.Id == 1) ,Details = "toetsenbord reageerd niet op aanslagen, ziet er wel in oorde uit", Status = Status.Pending},
                new Reparatieopdracht{Name="kappote accu", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Klant = klantens.FirstOrDefault(r => r.Id == 3) ,Details = "accu laat niet op, laptop start wel op met stroom aanvoer", Status = Status.Pending},
                new Reparatieopdracht{Name="blue screen", Startdate = DateTime.Parse("2020-10-21"), Enddate = DateTime.Parse("2020-10-22"), Klant = klantens.FirstOrDefault(r => r.Id == 4) ,Details = "computer geeft een blue screen op startup, lijkt verder in oorde", Status = Status.InProgress},
                new Reparatieopdracht{Name="kappote usb", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Klant = klantens.FirstOrDefault(r => r.Id == 2) ,Details = "usb werkt niet, vervanging warschijnlijk nodig", Status = Status.WaitingForParts},
                new Reparatieopdracht{Name="start niet op", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"), Klant = klantens.FirstOrDefault(r => r.Id == 3) ,Details = "laptop wijgert op te starten, lijkt harwarematig in orde", Status = Status.WaitingForParts},
                new Reparatieopdracht{Name="geen internet", Startdate = DateTime.Parse("2020-11-02"), Enddate = DateTime.Parse("2020-10-22"), Klant = klantens.FirstOrDefault(r => r.Id == 2) ,Details = "laptop wijgert met internet te verbinden, waarschijnlijk een kappote zender", Status = Status.Done, }
            };

            reparaties.ForEach(s => context.reparatieopdrachtens.Add(s));
            context.SaveChanges();

            
        }
    }
}