using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApiService _apiService;

        public ArticlesController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            try
            {
                var articles = await _apiService.GetAllArticlesAsync();
                return View(new ArticleListViewModel { Articles = articles });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving articles: {ex.Message}";
                return View(new ArticleListViewModel());
            }
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var article = await _apiService.GetArticleByIdAsync(id);
                if (article == null || article.Id == 0)
                {
                    return NotFound();
                }
                return View(article);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving article: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Articles/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var writers = await _apiService.GetAllWritersAsync();
                ViewBag.Writers = new SelectList(writers, "Id", "FullName");
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error loading writers: {ex.Message}";
                return View();
            }
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleModel article)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _apiService.CreateArticleAsync(article);
                    TempData["SuccessMessage"] = "Article created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                
                var writers = await _apiService.GetAllWritersAsync();
                ViewBag.Writers = new SelectList(writers, "Id", "FullName");
                return View(article);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error creating article: {ex.Message}";
                var writers = await _apiService.GetAllWritersAsync();
                ViewBag.Writers = new SelectList(writers, "Id", "FullName");
                return View(article);
            }
        }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var article = await _apiService.GetArticleByIdAsync(id);
                if (article == null || article.Id == 0)
                {
                    return NotFound();
                }
                
                var writers = await _apiService.GetAllWritersAsync();
                ViewBag.Writers = new SelectList(writers, "Id", "FullName", article.WriterId);
                return View(article);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving article: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleModel article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _apiService.UpdateArticleAsync(id, article);
                    TempData["SuccessMessage"] = "Article updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                
                var writers = await _apiService.GetAllWritersAsync();
                ViewBag.Writers = new SelectList(writers, "Id", "FullName", article.WriterId);
                return View(article);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating article: {ex.Message}";
                var writers = await _apiService.GetAllWritersAsync();
                ViewBag.Writers = new SelectList(writers, "Id", "FullName", article.WriterId);
                return View(article);
            }
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var article = await _apiService.GetArticleByIdAsync(id);
                if (article == null || article.Id == 0)
                {
                    return NotFound();
                }
                return View(article);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving article: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteArticleAsync(id);
                TempData["SuccessMessage"] = "Article deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting article: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 