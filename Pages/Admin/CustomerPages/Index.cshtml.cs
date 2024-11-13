using eCashier.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace eCashier.Pages.CustomerPages
{
    public class IndexModel : PageModel
    {
        private readonly eCashier.Data.ApplicationDbContext _context;

        public IndexModel(eCashier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            //Sort by ascending only, needs changes
            ViewData["SortOrder"] = sortOrder ?? "FirstName";
            Customer = await _context.Customers
                .OrderBy(ViewData["SortOrder"].ToString())
                .ToListAsync();
        }
    }
}
