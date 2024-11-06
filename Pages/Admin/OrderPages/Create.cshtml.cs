using eCashier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCashier.Pages.OrderPages
{
    public class CreateModel : PageModel
    {
        private readonly eCashier.Data.ApplicationDbContext _context;

        public CreateModel(eCashier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "FullName");
            Items = _context.Items.ToList();
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        [BindProperty]
        public IList<Item> Items { get; set; } = default!;
        [BindProperty]
        public IList<int> SelectedItems { get; set; } = default!;


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var order = Order;

            _context.Orders.Add(order);

            foreach (var itemId in SelectedItems)
            {
                var item = await _context.Items.FindAsync(itemId);
                order.Items.Add(item);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
