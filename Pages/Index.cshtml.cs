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
            var OptionList = new SelectList(ItemId, "Id", "Name");
            ViewData["ItemId"] = OptionList;
        }

        public async Task OnPost()
        {
            {
                var paymentService = new OttuPaymentService(
                    "https://sandbox.ottu.net",
                    "VA81bYIs.D6RazRH3MemovqYmS83KJgHTRq1W5UbF"
                    );

                var request = new PaymentRequest
                {
                    Type = "payment_request",
                    PgCodes = ["benefit-test"],
                    Amount = 100,
                    CurrencyCode = "BHD",
                    CustomerPhone = "33333333"

                };

                var response = await paymentService.CreatePaymentSessionAsync(request);
                var redirect = response.CheckoutUrl;

                Response.Redirect(redirect);
            }
        }
    }
}
