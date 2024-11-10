using eCashier.Models;
using eCashier.Ottu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
        [BindProperty]
        public Order Order { get; set; } = default!;
        [BindProperty]
        public IList<int> SelectedItems { get; set; } = default!;

        public void OnGet()
        {
            PopulateOptionList();
        }

        private void PopulateOptionList()
        {
            var ItemId = _context.Items.Where(i => i.IsVisible);
            var OptionList = new SelectList(ItemId, "Id", "Name");
            ViewData["ItemId"] = OptionList;
        }

        public JsonResult OnGetPrice(int itemId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);
            return new JsonResult(new
            {
                price = item?.Price ?? 0,
                allowAnyPrice = item?.AllowAnyPrice ?? false
            });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                PopulateOptionList();
                return Page();
            }

            int itemPrice = Item.Price;
            String customerPhone = Customer.Telephone;

            var paymentService = new PaymentService(
                "https://sandbox.ottu.net",
                "VA81bYIs.D6RazRH3MemovqYmS83KJgHTRq1W5UbF"
                );

            var request = new PaymentRequest
            {
                Type = "payment_request",
                PgCodes = ["benefit-test"],
                Amount = itemPrice,
                CurrencyCode = "BHD",
                CustomerPhone = customerPhone
            };

            var response = await paymentService.CreatePaymentSessionAsync(request);

            Order.CheckoutUrl = response.CheckoutUrl;

            HttpContext.Session.SetString("CustomerData", JsonSerializer.Serialize(Customer));
            HttpContext.Session.SetString("OttuData", JsonSerializer.Serialize(response));
            HttpContext.Session.SetString("ItemData", JsonSerializer.Serialize(SelectedItems));
            HttpContext.Session.SetString("PriceData", JsonSerializer.Serialize(itemPrice));


            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == Customer.Email);

            if (existingCustomer == null)
            {
                _context.Customers.Add(Customer);
                Order.Customer = Customer;
            }
            else
            {
                Order.Customer = existingCustomer;
            }

            foreach (var itemId in SelectedItems)
            {
                var item = await _context.Items.FindAsync(itemId);
                Order.Items.Add(item);
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Summary");
        }


    }
}
