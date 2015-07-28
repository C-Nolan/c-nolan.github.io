using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RideShare.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RideShare.DAL
{
    public class RideShareContext : DbContext
    {
        public RideShareContext() : base("RideShareContext")
        {
        }

        public DbSet<PostingModel> Postings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}