using GVB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GVB.DAL
{
    public class GVBDBContext : DbContext
    {

        public GVBDBContext() : base("GVBDBContext") { }

        public DbSet<Cattle> Cattle { get; set; }
        public DbSet<Dairy> Dairy { get; set; }
        public DbSet<Feedlot> Feedlot { get; set; }
        public DbSet<Deceased> Deceased { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<State> State { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}