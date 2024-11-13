using eCashier.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eCashier.Pages.OrderPages
{
    public class IndexModel : PageModel
    {
        private readonly eCashier.Data.ApplicationDbContext _context;

        public IndexModel(eCashier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; } = default!;
        public IList<ItemOrder> ItemOrders { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Items)
                .Include(o => o.ItemOrders)
                .ToListAsync();
        }
    }
}
