using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace KiteApp.Models
{
    public class KiteAppContext : DbContext
    {
        public KiteAppContext()
        {

        }

        //public virtual DbSet<Location> Locations { get; set; }
        //public virtual DbSet<Cuisine> Cuisines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=KiteApp;integrated security=True");
        }

        public KiteAppContext(DbContextOptions<KiteAppContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}