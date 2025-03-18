using Article.Api.Data;
using Article.Api.Models;
using Article.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Article.Api.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ArticleDbContext _context;

        public ArticleRepository(ArticleDbContext context)
        {
            _context = context;
        }

        public List<Models.Article> GetAll()
        {
            return _context.Articles.Where(a => a.IsActive == 1).ToList();
        }

        public Models.Article? GetById(int id)
        {
            return _context.Articles.FirstOrDefault(a => a.Id == id && a.IsActive == 1);
        }

        public int Delete(int id)
        {
            var article = _context.Articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return 0;
            }
            
            // Soft delete
            article.IsActive = 0;
            _context.SaveChanges();
            return 1;
        }

        public Models.Article Add(Models.Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return article;
        }

        public Models.Article Update(Models.Article article)
        {
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
            return article;
        }
    }
}
