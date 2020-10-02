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

        public DbSet<Reparatieopdrachten>reparatieopdrachtens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}