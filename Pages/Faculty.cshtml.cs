using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aubh.ecashier.Pages
{
    public class FacultyModel : PageModel
    {
        private readonly ILogger<FacultyModel> _logger;

        public FacultyModel(ILogger<FacultyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
