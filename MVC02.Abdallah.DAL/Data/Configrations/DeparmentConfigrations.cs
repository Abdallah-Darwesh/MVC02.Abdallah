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
    public class DeparmentConfigrations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Code).HasMaxLength(10).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(50).IsRequired();
            builder.Property(d => d.CreateAt).HasDefaultValueSql("getdate()");
        }
    }
}
