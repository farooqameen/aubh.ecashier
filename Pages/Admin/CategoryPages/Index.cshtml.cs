using eCashier.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eCashier.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly eCashier.Data.ApplicationDbContext _context;

        public IndexModel(eCashier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
