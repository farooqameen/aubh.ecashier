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
    public class DetailsModel : PageModel
    {
        private readonly eCashier.Data.ApplicationDbContext _context;

        public DetailsModel(eCashier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Item Item { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var item = await _context.Items.FirstOrDefaultAsync(m => m.Id == id);

            var item = await _context.Items
                .Include(i => i.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Item = item;
            }
            return Page();
        }
    }
}
