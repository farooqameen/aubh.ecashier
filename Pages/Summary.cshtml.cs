using eCashier.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IActionResult OnGet()
        {
            var customerData = HttpContext.Session.GetString("CustomerData");

            if (string.IsNullOrEmpty(customerData))
            {
                return RedirectToPage("./Index");
            }

            Customer = System.Text.Json.JsonSerializer.Deserialize<Customer>(customerData);
            return Page();
        }

        public IActionResult OnPost()
        {
            var customerData = HttpContext.Session.GetString("CustomerData");

            if (string.IsNullOrEmpty(customerData))
            {
                return RedirectToPage("./Index");
            }

            Customer = System.Text.Json.JsonSerializer.Deserialize<Customer>(customerData);

            return Page();
        }
    }
}