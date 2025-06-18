using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class FitnessDbContext : DbContext
    {
         public FitnessDbContext() : base()
        {

        }

        public FitnessDbContext(DbContextOptions options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL("Server=192.168.100.6;Database=FitnessDb;Uid=root;Pwd=root;");
                //optionsBuilder.UseMySQL("Server=127.0.0.1;Database=FitnessDb;Uid=root;Pwd=root;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<FitnessCenter> FitnessCenters { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Membership> Memberships { get; set; }
    }
}