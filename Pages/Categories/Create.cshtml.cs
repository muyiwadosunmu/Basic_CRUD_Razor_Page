
using Microsoft.AspNetCore.Mvc.RazorPages;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using AbbyWeb.Data;

namespace AbbyWeb.Pages.Categories
{
    public class Create : PageModel
    {
        private readonly ApplicationDBContext _db;
        private readonly ILogger<Create> _logger;

        public Create(ILogger<Create> logger, ApplicationDBContext db)
        {
            _db = db;
            _logger = logger;
        }


        [BindProperty]
        public Category Category { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {

                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

/**
public async Task<IActionResult> OnPost(Category category)
        {
            await _db.Category.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }*/