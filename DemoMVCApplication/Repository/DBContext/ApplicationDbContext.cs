using System;
using Microsoft.EntityFrameworkCore;
using DemoMVCApplication.Models.Entity;

namespace DemoMVCApplication.Repository.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure User entity with properties, relationships, indexes, etc.
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.Id);

                // Add properties, relationships, indexes as needed
                // Example:
                // entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                // entity.HasIndex(u => u.Email).IsUnique();
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
