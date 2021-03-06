﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Computer_Reparatieshop.Models;
using Computer_Reparatieshop.ViewModels;
using Microsoft.Ajax.Utilities;

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

            var reparateurs= new List<Reparateur>
            {
                new Reparateur{ FirstName ="Mathijs", InFix="van de", LastName="Kerkhof", FullName="Mathijs van de Kerkhof",Wage=9.99},
                new Reparateur{ FirstName ="Chris", InFix="", LastName="Vergeer",FullName="Chris Vergeer",Wage=12.50},
                new Reparateur{ FirstName ="Piere", InFix="van", LastName="Puffellen",FullName="Piere van Puffellen", Wage=13.30},
                new Reparateur{ FirstName ="Zack", InFix="", LastName="Hooij",FullName="Zack Hooij",Wage = 2.32},

            };

            reparateurs.ForEach(s => context.Reparateurs.Add(s));
            context.SaveChanges();

            var computerpart = new List<ComputerPart>
            {
                new ComputerPart{ Name="Intel Processor", Price=199, Vendor=vendor.Intel, Amount=43},
                new ComputerPart{ Name="AMD speakers", Price=299, Vendor=vendor.AMD, Amount=27},
                new ComputerPart{ Name="Intel Mousepad", Price=399, Vendor=vendor.Intel, Amount=93},
                new ComputerPart{ Name="Gygabyte Processor", Price=499, Vendor=vendor.Gigabyte, Amount=32},
                new ComputerPart{ Name="IBM Moederbord", Price=599, Vendor=vendor.IBM, Amount=14},
                new ComputerPart{ Name="ILED beeldscherm", Price=1000, Vendor=vendor.HP, Amount=12},
                new ComputerPart{ Name="GTX 4900", Price = 9999999, Vendor=vendor.Gigabyte, Amount=1}
            };

            computerpart.ForEach(s => context.ComputerParts.Add(s));
            context.SaveChanges();

            var reparaties = new List<Reparatieopdracht>
            {
                new Reparatieopdracht{Name="vervangen computerscherm", Startdate = DateTime.Parse("2020-10-02"), Enddate = DateTime.Parse("2020-10-22"),price = 120.00, Klant = klantens.FirstOrDefault(r => r.Id == 1) , ComputerParts = new List<ComputerPart>{context.ComputerParts.FirstOrDefault(r => r.Id == 1), context.ComputerParts.FirstOrDefault(r => r.Id == 3) }, Reparateur=reparateurs.FirstOrDefault(r =>r.Id==1), Details = "zit een barst in het beeldscherm, verder geen schade", Status = Status.Pending},
                new Reparatieopdracht{Name="defect toetsenbord", Startdate = DateTime.Parse("2020-10-01"), Enddate = DateTime.Parse("2020-10-22"),price = 50.00, Klant = klantens.FirstOrDefault(r => r.Id == 1),Reparateur=reparateurs.FirstOrDefault(r =>r.Id==1), ComputerParts = new List<ComputerPart>{context.ComputerParts.FirstOrDefault(r => r.Id == 4),context.ComputerParts.FirstOrDefault(r => r.Id == 6),context.ComputerParts.FirstOrDefault(r => r.Id == 5) },Details = "toetsenbord reageert niet op aanslagen, ziet er wel in orde uit", Status = Status.Pending},
                new Reparatieopdracht{Name="defect accu", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"),price = 340.00, Klant = klantens.FirstOrDefault(r => r.Id == 3),Reparateur=reparateurs.FirstOrDefault(r =>r.Id==2) , ComputerParts = new List<ComputerPart>{context.ComputerParts.FirstOrDefault(r => r.Id == 3) ,context.ComputerParts.FirstOrDefault(r => r.Id == 5) },Details = "accu laat niet op, laptop start wel op met stroomaanvoer", Status = Status.Pending},
                new Reparatieopdracht{Name="blue screen", Startdate = DateTime.Parse("2020-10-21"), Enddate = DateTime.Parse("2020-10-22"),price = 800.00, Klant = klantens.FirstOrDefault(r => r.Id == 4),Reparateur=reparateurs.FirstOrDefault(r =>r.Id==3) , ComputerParts = new List<ComputerPart>{context.ComputerParts.FirstOrDefault(r => r.Id == 1),context.ComputerParts.FirstOrDefault(r => r.Id == 7) },Details = "computer geeft een blue screen bij startup, lijkt verder in orde", Status = Status.InProgress},
                new Reparatieopdracht{Name="defect aan usbpoort", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"),price = 23.45, Klant = klantens.FirstOrDefault(r => r.Id == 2),Reparateur=reparateurs.FirstOrDefault(r =>r.Id==4) , ComputerParts = new List<ComputerPart>{context.ComputerParts.FirstOrDefault(r => r.Id == 5) },Details = "usb werkt niet, vervanging waarschijnlijk nodig", Status = Status.WaitingForParts},
                new Reparatieopdracht{Name="start niet op", Startdate = DateTime.Parse("2020-10-12"), Enddate = DateTime.Parse("2020-10-22"),price = 634.99, Klant = klantens.FirstOrDefault(r => r.Id == 3),Reparateur=reparateurs.FirstOrDefault(r =>r.Id==3) , ComputerParts = new List<ComputerPart>{context.ComputerParts.FirstOrDefault(r => r.Id == 1),context.ComputerParts.FirstOrDefault(r => r.Id == 3) },Details = "laptop weigert op te starten, lijkt hardwarematig in orde", Status = Status.WaitingForParts},
                new Reparatieopdracht{Name="geen internet", Startdate = DateTime.Parse("2020-11-02"), Enddate = DateTime.Parse("2020-10-22"),price = 35999.99, Klant = klantens.FirstOrDefault(r => r.Id == 2),Reparateur=reparateurs.FirstOrDefault(r =>r.Id==2) , ComputerParts = new List<ComputerPart>{ context.ComputerParts.FirstOrDefault(r => r.Id == 3),context.ComputerParts.FirstOrDefault(r => r.Id == 6),context.ComputerParts.FirstOrDefault(r => r.Id == 7)},Details = "laptop weigert met internet te verbinden, waarschijnlijk een defecte zender", Status = Status.Done, }
            };

            reparaties.ForEach(s => context.reparatieopdrachtens.Add(s));
            context.SaveChanges();



        }
    }
}