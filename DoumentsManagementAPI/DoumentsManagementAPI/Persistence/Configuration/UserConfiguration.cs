using DoumentsManagementAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.UserId);

            builder
                .Property(u => u.UserId)
                .UseIdentityColumn();

            builder
                .Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(a => a.EmailAddress)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Users");
        }
    }
}   
