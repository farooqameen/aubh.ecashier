using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eCashier.Data;
using eCashier.Models;

namespace eCashier.Pages.OrderPages
{
    public class IndexModel : PageModel
    {
        private readonly eCashier.Data.ApplicationDbContext _context;

        public IndexModel(eCashier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
