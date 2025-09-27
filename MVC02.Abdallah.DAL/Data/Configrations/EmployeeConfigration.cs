using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Abdallah.DAL.Models;

namespace MVC02.Abdallah.DAL.Data.Configrations
{
    internal class EmployeeConfigration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Address).HasMaxLength(200);
            builder.Property(e => e.Phone).HasMaxLength(15);
            builder.Property(e => e.Salary).HasColumnType("decimal(18,2)");
            builder.Property(e => e.HireDate).IsRequired();
            builder.Property(e => e.CreateAt).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.isActive).HasDefaultValue(true);
            builder.Property(e => e.isDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.SetNull);


        }

    }
}
