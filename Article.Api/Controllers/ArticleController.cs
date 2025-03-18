using Article.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Article.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        //constructor injection 
        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet]
        public IActionResult GetArticles()
        {
            return Ok(_articleRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetArticle(int id)
        {
            var detailsArticle = _articleRepository.GetById(id);
            if (detailsArticle is null)
            {
                return NotFound();
            }
            return Ok(detailsArticle);
        }

        [HttpPost]
        public IActionResult CreateArticle([FromBody] Models.Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var createdArticle = _articleRepository.Add(article);
            return CreatedAtAction(nameof(GetArticle), new { id = createdArticle.Id }, createdArticle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArticle(int id, [FromBody] Models.Article article)
        {
            if (id != article.Id)
            {
                return BadRequest("ID mismatch");
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var existingArticle = _articleRepository.GetById(id);
            if (existingArticle == null)
            {
                return NotFound();
            }
            
            var updatedArticle = _articleRepository.Update(article);
            return Ok(updatedArticle);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var deletedCount = _articleRepository.Delete(id);
            if (deletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
