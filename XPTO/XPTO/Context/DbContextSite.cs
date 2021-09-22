using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using XPTO.Models;

namespace XPTO.Context
{
    public class DbContextSite : DbContext
    {
        DbSet<Pessoa> pessoas { get; set; }

        public DbContextSite() : base("site1")
        {
            Database.SetInitializer<DbContextSite>(new NullDatabaseInitializer<DbContextSite>());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }
    }
}