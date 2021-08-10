using DoumentsManagementAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Persistence.Configuration
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder
                .HasKey(m => m.DocId);
            builder
                .Property(m => m.DocId)
                .UseIdentityColumn();
            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(m => m.PublishedDate)
                .IsRequired();
            builder
                .HasOne(m => m.Type)
                .WithMany(c => c.Documents)
                .HasForeignKey(m => m.CategoryId);
            builder
                .HasOne(m => m.DocumentAuthor)
                .WithMany(a => a.Documents)
                .HasForeignKey(m => m.AuthorId);
            builder
                .ToTable("Documents");

        }
    }
}
