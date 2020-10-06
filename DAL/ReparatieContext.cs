using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Computer_Reparatieshop.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace Computer_Reparatieshop.DAL
{
    public class ReparatieContext : DbContext
    {
        public ReparatieContext() : base("ReparatieContext")
        {

        }

        public DbSet<Reparatieopdracht>reparatieopdrachtens { get; set; }
        public DbSet<Klant> klantens { get; set; }

        public DbSet<Reparateur> Reparateurs { get; set; }
        public DbSet<ComputerPart> ComputerParts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}