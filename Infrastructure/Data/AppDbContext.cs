
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        public DbSet<Owner> Owners { get; set; }
        //public DbSet<Address> Addresses { get; set; }//the address is defult property of the Owner entity, so no need to define it separately
        public DbSet<PortfolioItem> PortfolioItems { get; set; }

        // Define DbSets for your entities here
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
