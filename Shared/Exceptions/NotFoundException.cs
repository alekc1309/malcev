using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Shared.Exceptions
{
    public class NotFoundException : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
