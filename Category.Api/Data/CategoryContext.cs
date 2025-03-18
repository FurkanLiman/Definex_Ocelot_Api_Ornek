using Category.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Category.Api.Data
{
    public class CategoryContext : DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {
        }

        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<CategoryModel>().HasData(
                new CategoryModel { Id = 1, Name = "Technology", Description = "Technology related content", CreatedDate = DateTime.Now },
                new CategoryModel { Id = 2, Name = "Health", Description = "Health and wellness content", CreatedDate = DateTime.Now },
                new CategoryModel { Id = 3, Name = "Business", Description = "Business and finance content", CreatedDate = DateTime.Now }
            );
        }
    }
} 