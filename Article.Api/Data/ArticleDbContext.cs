using Article.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Article.Api.Data
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext(DbContextOptions<ArticleDbContext> options) : base(options)
        {
        }

        public DbSet<Models.Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Models.Article>().HasData(
                new Models.Article
                {
                    Id = 1,
                    Title = "Introduction to Microservices",
                    Content = "Microservices architecture is an approach to application development...",
                    PublishedDate = DateTime.Now.AddDays(-10),
                    WriterId = 1,
                    IsActive = 1
                },
                new Models.Article
                {
                    Id = 2,
                    Title = "API Gateway Pattern",
                    Content = "API Gateway is a pattern where all client requests pass through a single entry point...",
                    PublishedDate = DateTime.Now.AddDays(-5),
                    WriterId = 1,
                    IsActive = 1
                },
                new Models.Article
                {
                    Id = 3,
                    Title = "Entity Framework Core Basics",
                    Content = "Entity Framework Core is a lightweight ORM framework for .NET applications...",
                    PublishedDate = DateTime.Now.AddDays(-2),
                    WriterId = 2,
                    IsActive = 1
                }
            );
        }
    }
} 