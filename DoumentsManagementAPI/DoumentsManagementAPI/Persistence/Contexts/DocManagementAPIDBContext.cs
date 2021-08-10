using DoumentsManagementAPI.Domain.Models;
using DoumentsManagementAPI.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoumentsManagementAPI.Persistence.Contexts
{
    public class DocManagementAPIDBContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        public DocManagementAPIDBContext(DbContextOptions<DocManagementAPIDBContext> options): base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new DocumentConfiguration());
            builder
                .ApplyConfiguration(new AuthorConfiguration());
            builder
                .ApplyConfiguration(new UserConfiguration());
            builder
                .ApplyConfiguration(new CategoryConfiguration());
        }


    }
}
