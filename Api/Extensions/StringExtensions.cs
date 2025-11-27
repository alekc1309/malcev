using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Extensions
{
    public class StringExtensions : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
