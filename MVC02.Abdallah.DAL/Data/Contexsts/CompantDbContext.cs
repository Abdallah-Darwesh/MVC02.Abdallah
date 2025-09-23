using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC02.Abdallah.DAL.Models;

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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost\\MSSQLSERVER03;Database=EFCoreDB;Trusted_Connection=True;TrustServerCertificate=True;"
                );
            }
        }

        public DbSet<Models.Department> Departments { get; set; }

        public DbSet<Employees> Employees { get; set; }
    }
}
