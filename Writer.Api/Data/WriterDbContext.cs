using Microsoft.EntityFrameworkCore;
using Writer.Api.Models;

namespace Writer.Api.Data
{
    public class WriterDbContext : DbContext
    {
        public WriterDbContext(DbContextOptions<WriterDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Writer> Writers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Models.Writer>().HasData(
                new Models.Writer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    CreatedDate = DateTime.Now.AddDays(-30),
                    IsActive = 1
                },
                new Models.Writer
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    CreatedDate = DateTime.Now.AddDays(-20),
                    IsActive = 1
                },
                new Models.Writer
                {
                    Id = 3,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bob.johnson@example.com",
                    CreatedDate = DateTime.Now.AddDays(-10),
                    IsActive = 1
                }
            );
        }
    }
} 