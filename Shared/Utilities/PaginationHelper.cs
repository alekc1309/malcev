using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Shared.Utilities
{
    public class PaginationHelper : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
