using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eCashier.Data;
using eCashier.Models;

namespace eCashier.Pages.ItemPages
{
    public class IndexModel : PageModel
    {
        private readonly eCashier.Data.ApplicationDbContext _context;

        public IndexModel(eCashier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Item> Item { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Item = await _context.Items
                .Include(i => i.Category).ToListAsync();
        }
    }
}
