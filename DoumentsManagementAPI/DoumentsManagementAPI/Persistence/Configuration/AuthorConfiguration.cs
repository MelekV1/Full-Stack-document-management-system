using DoumentsManagementAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Persistence.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasKey(a => a.AuthorId);
            builder
                .Property(a => a.AuthorId)
                .UseIdentityColumn();
            builder
                .Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .ToTable("Authors");
        }
    }
}
