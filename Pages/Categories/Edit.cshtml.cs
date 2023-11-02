using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AbbyWeb.Models;
using AbbyWeb.Data;
using Microsoft.Extensions.Logging;

namespace AbbyWeb.Pages.Categories
{
    public class Edit : PageModel
    {
        private readonly ApplicationDBContext _db;
        private readonly ILogger<Edit> _logger;

        public Edit(ILogger<Edit> logger, ApplicationDBContext db)
        {
            _db = db;
            _logger = logger;
        }
        [BindProperty]
        public Category Category { get; set; }


        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            // Category = _db.Category.First((u) => u.Id == id);
            // Category = _db.Category.SingleOrDefault((u) => u.Id == id);
            // Category = _db.Category.Where((u) => u.Id == id);


        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {

                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}