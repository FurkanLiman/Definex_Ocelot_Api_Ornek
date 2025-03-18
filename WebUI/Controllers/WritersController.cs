using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Controllers
{
    public class WritersController : Controller
    {
        private readonly ApiService _apiService;

        public WritersController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Writers
        public async Task<IActionResult> Index()
        {
            try
            {
                var writers = await _apiService.GetAllWritersAsync();
                return View(new WriterListViewModel { Writers = writers });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving writers: {ex.Message}";
                return View(new WriterListViewModel());
            }
        }

        // GET: Writers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var writer = await _apiService.GetWriterByIdAsync(id);
                if (writer == null || writer.Id == 0)
                {
                    return NotFound();
                }
                return View(writer);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving writer: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Writers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Writers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WriterModel writer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _apiService.CreateWriterAsync(writer);
                    TempData["SuccessMessage"] = "Writer created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                return View(writer);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error creating writer: {ex.Message}";
                return View(writer);
            }
        }

        // GET: Writers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var writer = await _apiService.GetWriterByIdAsync(id);
                if (writer == null || writer.Id == 0)
                {
                    return NotFound();
                }
                return View(writer);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving writer: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Writers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WriterModel writer)
        {
            if (id != writer.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _apiService.UpdateWriterAsync(id, writer);
                    TempData["SuccessMessage"] = "Writer updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                return View(writer);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating writer: {ex.Message}";
                return View(writer);
            }
        }

        // GET: Writers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var writer = await _apiService.GetWriterByIdAsync(id);
                if (writer == null || writer.Id == 0)
                {
                    return NotFound();
                }
                return View(writer);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving writer: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Writers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteWriterAsync(id);
                TempData["SuccessMessage"] = "Writer deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting writer: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
} 