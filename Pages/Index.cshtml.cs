using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aubh.ecashier.Pages
{
    public class IndexModel : PageModel
    {


        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public Service? Service { get; set; }

        public void OnGet()
        {

        }

    }
}
