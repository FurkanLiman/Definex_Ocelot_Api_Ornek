using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApiService _apiService;

        public CategoriesController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            try
            {
                var categories = await _apiService.GetAllCategoriesAsync();
                return View(new CategoryListViewModel { Categories = categories });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving categories: {ex.Message}";
                return View(new CategoryListViewModel());
            }
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var category = await _apiService.GetCategoryByIdAsync(id);
                if (category == null || category.Id == 0)
                {
                    return NotFound();
                }
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving category: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.CreateCategoryAsync(category);
                    TempData["SuccessMessage"] = "Category created successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error creating category: {ex.Message}";
                    ModelState.AddModelError("", "Error creating category. Please try again.");
                }
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var category = await _apiService.GetCategoryByIdAsync(id);
                if (category == null || category.Id == 0)
                {
                    return NotFound();
                }
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving category: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryModel category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _apiService.UpdateCategoryAsync(id, category);
                    TempData["SuccessMessage"] = "Category updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating category: {ex.Message}";
                    ModelState.AddModelError("", "Error updating category. Please try again.");
                }
            }

            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var category = await _apiService.GetCategoryByIdAsync(id);
                if (category == null || category.Id == 0)
                {
                    return NotFound();
                }
                return View(category);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving category: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteCategoryAsync(id);
                TempData["SuccessMessage"] = "Category deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting category: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 