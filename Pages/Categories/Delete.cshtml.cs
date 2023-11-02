using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AbbyWeb.Pages.Categories
{
    public class Delete : PageModel
    {
        private readonly ApplicationDBContext _db;
        private readonly ILogger<Delete> _logger;

        public Delete(ILogger<Delete> logger, ApplicationDBContext db)
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

        public async Task<IActionResult> OnPost()
        {

            var categoryFromDB = _db.Category.Find(Category.Id);
            if (categoryFromDB != null)
            {
                _db.Category.Remove(categoryFromDB);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }


    }
}