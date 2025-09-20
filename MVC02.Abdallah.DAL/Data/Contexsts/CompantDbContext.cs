using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC02.Abdallah.DAL.Data.Contexsts
{
    public class CompantDbContext : DbContext
    {

        public CompantDbContext(DbContextOptions<CompantDbContext>options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=.;Database =CompanyG02;Trusted_connection =True; TrustServerCertificate =True");
        }

        public DbSet<Models.Department> Departments { get; set; }
    }
}
