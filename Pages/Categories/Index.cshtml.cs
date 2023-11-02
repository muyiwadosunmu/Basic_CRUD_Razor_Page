
using AbbyWeb.Data;
using AbbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AbbyWeb.Pages.Categories
{
    public class Index : PageModel
    {

        // We are about to use Dependency Injection here
        private readonly ApplicationDBContext _db;
        private readonly ILogger<Index> _logger;
        public IEnumerable<Category> Categories { get; set; }


        // The constructor below now will help us to inject some dependencies in our class
        public Index(ILogger<Index> logger, ApplicationDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category;

        }
    }
}