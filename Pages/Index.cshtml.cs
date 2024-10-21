using eCashier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace eCashier.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly eCashier.Data.ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger
            , eCashier.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; } = default!;
        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public void OnGet()
        {
            var ItemId = _context.Items.Where(i => i.IsVisible);
            ViewData["ItemId"] = new SelectList(ItemId, "Id", "Name");
        }
    }
}
