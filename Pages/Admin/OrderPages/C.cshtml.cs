using eCashier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCashier.Pages.OrderPages
{
    public class CModel : PageModel
    {
        private readonly eCashier.Data.ApplicationDbContext _context;

        public CModel(eCashier.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "NameFull");
            Console.WriteLine(_context.Items);
            Items = _context.Items.ToList();

            Options = _context.Items.Select(
                o => new SelectListItem
                {
                    Value = o.Id.ToString(),
                    Text = o.Name,
                }).ToList();

            Console.WriteLine(Options);

            return Page();
        }

        public List<SelectListItem> Options { get; set; } = default!;
        [BindProperty]
        public Order Order { get; set; } = default!;
        [BindProperty]
        public IList<Item> Items { get; set; } = default!;
        [BindProperty]
        public List<int> SelectedItems { get; set; } = default!;


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
