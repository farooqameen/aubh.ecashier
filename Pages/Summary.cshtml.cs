using eCashier.Models;
using eCashier.Ottu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace eCashier.Pages
{
    public class SummaryModel : PageModel
    {
        private readonly ILogger<SummaryModel> _logger;
        private readonly eCashier.Data.ApplicationDbContext _context;

        public SummaryModel(ILogger<SummaryModel> logger
            , eCashier.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Customer Customer { get; set; } = default!;
        public PaymentResponse Payment { get; set; } = default!;
        public Item Item { get; set; } = default!;

        public IActionResult OnGet()
        {
            var customerData = HttpContext.Session.GetString("CustomerData");
            var ottuData = HttpContext.Session.GetString("OttuData");
            var itemData = HttpContext.Session.GetString("ItemData");

            if (string.IsNullOrEmpty(customerData) || string.IsNullOrEmpty(ottuData))
            {
                return RedirectToPage("./Index");
            }

            Customer = JsonSerializer.Deserialize<Customer>(customerData);
            Payment = JsonSerializer.Deserialize<PaymentResponse>(ottuData);
            //Item = JsonSerializer.Deserialize<Item>(itemData);

            return Page();
        }

    }
}