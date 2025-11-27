using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Extensions
{
    public class EnumerableExtensions : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
