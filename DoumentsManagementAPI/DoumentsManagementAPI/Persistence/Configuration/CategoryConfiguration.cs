using DoumentsManagementAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.CategoryId);
            builder
                .Property(c => c.CategoryId)
                .UseIdentityColumn();
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .ToTable("Categories");
        }
    }
}
