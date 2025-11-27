using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Shared.Exceptions
{
    public class ValidationException : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
